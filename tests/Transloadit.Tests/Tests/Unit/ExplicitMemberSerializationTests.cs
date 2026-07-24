using Newtonsoft.Json.Linq;
using Transloadit.Models;
using Transloadit.Tests.Infrastructure;
using Xunit;

namespace Transloadit.Tests.Tests.Unit
{
    // ensures members that are NOT public auto-properties are still serialized/deserialized correctly by
    // whichever serializer is active for the current TFM (System.Text.Json on net6+, Newtonsoft on net461):
    //   - ResponseBase implements IResponseBase *explicitly* (ok/message/error/reason/http_code)
    //   - BaseParams.Auth is *internal*
    //   - BaseParams.EnableSignatureAuth is internal AND ignored, so it must never appear in JSON
    // (JObject is used only to inspect the produced JSON; it does not drive serialization.)
    public class ExplicitMemberSerializationTests
    {
        [Fact]
        public void ResponseBase_ExplicitInterfaceMembers_Deserialize()
        {
            const string json =
                "{\"ok\":\"ASSEMBLY_COMPLETED\",\"message\":\"done\",\"error\":\"SOME_ERROR\",\"reason\":\"why\",\"http_code\":429}";

            var response = TestSerializer.Default.Deserialize<ResponseBase>(json);

            Assert.Equal("ASSEMBLY_COMPLETED", response.Base.Ok);
            Assert.Equal("done", response.Base.Message);
            Assert.Equal("SOME_ERROR", response.Base.Error);
            Assert.Equal("why", response.Base.Reason);
            Assert.Equal(429, response.Base.HttpCode);
        }

        [Fact]
        public void ResponseBase_ExplicitInterfaceMembers_Serialize()
        {
            var response = new ResponseBase();
            response.Base.Ok = "OK";
            response.Base.Message = "done";
            response.Base.Error = "SOME_ERROR";
            response.Base.Reason = "why";
            response.Base.HttpCode = 200;

            var json = JObject.Parse(TestSerializer.Default.Serialize(response));

            Assert.Equal("OK", (string)json["ok"]);
            Assert.Equal("done", (string)json["message"]);
            Assert.Equal("SOME_ERROR", (string)json["error"]);
            Assert.Equal("why", (string)json["reason"]);
            Assert.Equal(200, (int)json["http_code"]);
        }

        [Fact]
        public void ResponseBase_ExplicitInterfaceMembers_RoundTrip()
        {
            var original = new ResponseBase();
            original.Base.Ok = "ASSEMBLY_EXECUTING";
            original.Base.HttpCode = 202;

            var roundTripped = TestSerializer.Default.Deserialize<ResponseBase>(
                TestSerializer.Default.Serialize(original));

            Assert.Equal("ASSEMBLY_EXECUTING", roundTripped.Base.Ok);
            Assert.Equal(202, roundTripped.Base.HttpCode);
        }

        [Fact]
        public void ResponseBase_UnsetExplicitMembers_AreOmitted()
        {
            var response = new ResponseBase();
            response.Base.Ok = "OK";

            var json = JObject.Parse(TestSerializer.Default.Serialize(response));

            Assert.Equal("OK", (string)json["ok"]);
            // null explicit members are not emitted
            Assert.Null(json["error"]);
            Assert.Null(json["message"]);
            Assert.Null(json["http_code"]);
        }

        [Fact]
        public void BaseParams_InternalAuth_Serializes()
        {
            var parameters = new BaseParams();
            parameters.SetAuth(new AuthParams { Key = "my-key", MaxSize = 100 });

            var json = JObject.Parse(TestSerializer.Default.Serialize(parameters));

            Assert.NotNull(json["auth"]);
            Assert.Equal("my-key", (string)json["auth"]["key"]);
            Assert.Equal(100, (int)json["auth"]["max_size"]);
        }

        [Fact]
        public void BaseParams_IgnoredInternalMember_IsNeverSerialized()
        {
            var parameters = new BaseParams();
            parameters.SetAuth(new AuthParams { Key = "k" });

            var json = JObject.Parse(TestSerializer.Default.Serialize(parameters));

            // EnableSignatureAuth is internal + ignored; it must not leak into the payload under any casing
            Assert.Null(json["enable_signature_auth"]);
            Assert.Null(json["enableSignatureAuth"]);
            Assert.Null(json["EnableSignatureAuth"]);
        }
    }
}
