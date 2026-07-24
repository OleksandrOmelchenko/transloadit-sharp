using System;
using System.Collections.Generic;
using Transloadit.Models;
using Transloadit.Models.Assemblies;
using Transloadit.Models.Billing;
using Transloadit.Models.Templates;
using Transloadit.Models.Tokens;
using Transloadit.Tests.Infrastructure;
using Xunit;

namespace Transloadit.Tests.Tests.Unit
{
    // offline deserialization of the response models from canned JSON, via the active serializer
    // (System.Text.Json on net6+, Newtonsoft on net461). Covers the explicit-interface envelope fields
    // (ok/http_code), nested collections, and the billing camelCase / address_1 override names.
    public class ResponseDeserializationTests
    {
        [Fact]
        public void AssemblyResponse_Deserializes_EnvelopeAndNestedResults()
        {
            const string json =
                "{\"ok\":\"ASSEMBLY_COMPLETED\",\"http_code\":200,\"assembly_id\":\"abc\",\"num_input_files\":2," +
                "\"template_id\":\"t1\",\"results\":{\"resized\":[{\"id\":\"f1\"},{\"id\":\"f2\"}]}}";

            var response = TestSerializer.Default.Deserialize<AssemblyResponse>(json);

            Assert.True(response.IsSuccessResponse());
            Assert.Equal("ASSEMBLY_COMPLETED", response.Base.Ok);
            Assert.Equal(200, response.Base.HttpCode);
            Assert.Equal("abc", response.AssemblyId);
            Assert.Equal(2, response.NumInputFiles);
            Assert.Equal("t1", response.TemplateId);
            Assert.Equal(2, response.Results["resized"].Count);
        }

        [Theory]
        [InlineData("2020/01/09 12:02:06 GMT")] // the actual Transloadit response format (not ISO 8601)
        [InlineData("2024-02-20T01:52:04+00:00")] // ISO 8601 must still parse
        [InlineData("2024-02-20T01:52:04Z")]
        public void ResponseDates_ParseAcrossFormats(string raw)
        {
            var response = TestSerializer.Default.Deserialize<AssemblyResponse>(
                "{\"ok\":\"ASSEMBLY_COMPLETED\",\"execution_start\":\"" + raw + "\"}");

            // all four inputs denote a UTC instant; the converter must parse them without throwing
            Assert.NotNull(response.ExecutionStart);
            Assert.Equal(TimeSpan.Zero, response.ExecutionStart.Value.Offset);
            Assert.True(response.ExecutionStart.Value.Year >= 2020);
        }

        [Fact]
        public void AssemblyResponse_HandlesNullDatesAndLargeFileSizes()
        {
            // failed/in-progress assemblies send null for lifecycle dates and durations (verified against the live
            // API), and media files routinely exceed 2 GB (int range) — none of these may crash deserialization
            const string json =
                "{\"ok\":\"ASSEMBLY_EXECUTING\",\"assembly_id\":\"abc\"," +
                "\"start_date\":null,\"execution_start\":null,\"execution_duration\":null," +
                "\"ignored_error_count\":2,\"ignored_errors\":[{\"name\":\"x\"}]," +
                "\"uploads\":[{\"size\":3221225472}]}";

            var response = TestSerializer.Default.Deserialize<AssemblyResponse>(json);

            Assert.Null(response.StartDate);
            Assert.Null(response.ExecutionStart);
            Assert.Null(response.ExecutionDuration);
            Assert.Equal(2, response.IgnoredErrorCount);
            Assert.Single(response.IgnoredErrors);
            Assert.Equal(3221225472L, response.Uploads[0].Size);
        }

        [Fact]
        public void BillingResponse_Deserializes_CamelCaseAndOverrideNames()
        {
            const string json =
                "{\"ok\":\"BILL_FOUND\",\"invoice_id\":\"inv-1\",\"address_1\":\"line 1\",\"address_2\":\"line 2\"," +
                "\"robots\":{\"/image/resize\":{\"rawGb\":1.5,\"gbFactorApplied\":2,\"freeGb\":0.25}}}";

            var response = TestSerializer.Default.Deserialize<BillingResponse>(json);

            Assert.Equal("inv-1", response.InvoiceId);
            Assert.Equal("line 1", response.Address1);
            Assert.Equal("line 2", response.Address2);

            var robot = response.Robots["/image/resize"];
            Assert.Equal(1.5m, robot.RawGb);
            Assert.Equal(2m, robot.GbFactorApplied);
            Assert.Equal(0.25m, robot.FreeGb);
        }

        [Fact]
        public void Fields_DeserializeToInferredClrTypes_NeverJsonElement()
        {
            // untyped Dictionary<string, object> members must expose the same boxed CLR types on both engines.
            // System.Text.Json otherwise leaves them as JsonElement, diverging from Newtonsoft (boxed long/string/...).
            const string json =
                "{\"ok\":\"X\",\"fields\":{\"s\":\"str\",\"n\":7,\"f\":1.5,\"b\":true,\"nested\":{\"k\":1},\"arr\":[1,2]}}";

            var response = TestSerializer.Default.Deserialize<AssemblyResponse>(json);

            Assert.IsType<string>(response.Fields["s"]);
            Assert.IsType<long>(response.Fields["n"]);
            Assert.Equal(7L, response.Fields["n"]);
            Assert.IsType<double>(response.Fields["f"]);
            Assert.IsType<bool>(response.Fields["b"]);

            // nested containers are walkable types, never a raw System.Text.Json.JsonElement
            foreach (var key in new[] { "nested", "arr" })
            {
                Assert.DoesNotContain("JsonElement", response.Fields[key].GetType().FullName);
            }
        }

        [Theory]
        [InlineData("1", true)]
        [InlineData("0", false)]
        [InlineData("\"1\"", true)]
        [InlineData("\"0\"", false)]
        [InlineData("true", true)]
        [InlineData("false", false)]
        public void BooleanToInt_ReadsNumberStringAndBoolTokens(string rawValue, bool expected)
        {
            // both engines must coerce number/string/bool shapes without throwing
            var response = TestSerializer.Default.Deserialize<TemplateResponse>(
                "{\"require_signature_auth\":" + rawValue + "}");

            Assert.Equal(expected, response.RequireSignatureAuth);
        }

        [Fact]
        public void Deserialization_IsCaseInsensitive()
        {
            // Newtonsoft matches property names case-insensitively; System.Text.Json must too
            var response = TestSerializer.Default.Deserialize<ResponseBase>("{\"OK\":\"DONE\",\"HTTP_CODE\":200}");

            Assert.Equal("DONE", response.Base.Ok);
            Assert.Equal(200, response.Base.HttpCode);
        }

        [Fact]
        public void TokenResponse_Deserializes()
        {
            const string json =
                "{\"access_token\":\"tok\",\"token_type\":\"Bearer\",\"expires_in\":3600,\"scope\":\"s\"}";

            var response = TestSerializer.Default.Deserialize<TokenResponse>(json);

            Assert.Equal("tok", response.AccessToken);
            Assert.Equal("Bearer", response.TokenType);
            Assert.Equal(3600, response.ExpiresIn);
            Assert.Equal("s", response.Scope);
        }
    }
}
