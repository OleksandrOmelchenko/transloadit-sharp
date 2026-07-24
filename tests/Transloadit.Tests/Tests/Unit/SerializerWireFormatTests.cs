using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Transloadit.Models;
using Transloadit.Models.Billing;
using Transloadit.Models.Robots;
using Transloadit.Models.Robots.ImageManipulation;
using Transloadit.Models.Templates;
using Transloadit.Tests.Infrastructure;
using Xunit;

namespace Transloadit.Tests.Tests.Unit
{
    // wire-format regression via the active serializer (System.Text.Json on net6+, Newtonsoft on net461):
    // AnyOf arms, the explicit-name overrides (camelCase billing, pagesize, imagemagick_stack), bool->int
    // fields, date formats, and null omission — all through TestSerializer.Default so both engines are covered.
    public class SerializerWireFormatTests
    {
        private static JObject Serialize(object value) => JObject.Parse(TestSerializer.Default.Serialize(value));

        [Fact]
        public void AnyOf_StringArm_SerializesAsString()
        {
            var json = Serialize(new ImageResizeRobot { Use = "step-1" });
            Assert.Equal(JTokenType.String, json["use"].Type);
            Assert.Equal("step-1", (string)json["use"]);
        }

        [Fact]
        public void AnyOf_ListArm_SerializesAsArray()
        {
            var json = Serialize(new ImageResizeRobot { Use = new List<string> { "a", "b" } });
            Assert.Equal(JTokenType.Array, json["use"].Type);
            Assert.Equal(new[] { "a", "b" }, json["use"].ToObject<string[]>());
        }

        [Fact]
        public void AnyOf_AdvancedUseArm_SerializesAsObject()
        {
            var json = Serialize(new ImageResizeRobot
            {
                Use = new AdvancedUse { Steps = new List<string> { "x" }, BundleSteps = true },
            });
            Assert.Equal(JTokenType.Object, json["use"].Type);
            Assert.True((bool)json["use"]["bundle_steps"]);
            Assert.Equal("x", (string)json["use"]["steps"][0]);
        }

        [Fact]
        public void AnyOf_BoolArm_SerializesAsBool()
        {
            var json = Serialize(new ImageResizeRobot { OutputMeta = true });
            Assert.Equal(JTokenType.Boolean, json["output_meta"].Type);
            Assert.True((bool)json["output_meta"]);
        }

        [Fact]
        public void AnyOf_NestedObjectArm_SerializesNestedObject()
        {
            var json = Serialize(new ImageResizeRobot { OutputMeta = new OutputMeta { DominantColors = true } });
            Assert.Equal(JTokenType.Object, json["output_meta"].Type);
            Assert.True((bool)json["output_meta"]["dominant_colors"]);
        }

        [Fact]
        public void AnyOf_IgnoreErrorsListArm_SerializesAsArray()
        {
            var json = Serialize(new ImageResizeRobot { IgnoreErrors = new List<string> { "meta" } });
            Assert.Equal("meta", (string)json["ignore_errors"][0]);
        }

        [Fact]
        public void BooleanToInt_SerializesAsInteger()
        {
            var json = Serialize(new TemplateRequest { Name = "n", RequireSignatureAuth = true });
            Assert.Equal(JTokenType.Integer, json["require_signature_auth"].Type);
            Assert.Equal(1, (int)json["require_signature_auth"]);
        }

        [Fact]
        public void BooleanToInt_WhenUnset_IsOmitted()
        {
            // require_signature_auth is nullable, so an unset value must not force "0" onto e.g. a template rename
            var json = Serialize(new TemplateRequest { Name = "n" });
            Assert.Null(json["require_signature_auth"]);
        }

        [Fact]
        public void CamelCaseBillingOverrides_ArePreserved()
        {
            var json = Serialize(new RobotBilling { RawGb = 1.5m, GbFactorApplied = 2m });
            Assert.Equal(1.5m, (decimal)json["rawGb"]);
            Assert.Equal(2m, (decimal)json["gbFactorApplied"]);
            // must not be snake_cased
            Assert.Null(json["raw_gb"]);
            Assert.Null(json["gb_factor_applied"]);
        }

        [Fact]
        public void ExplicitNameOverrides_PagesizeAndImagemagickStack()
        {
            var pagination = Serialize(new PaginationParams { PageSize = 10 });
            Assert.Equal(10, (int)pagination["pagesize"]);
            Assert.Null(pagination["page_size"]);

            var robot = Serialize(new ImageResizeRobot { ImageMagickStack = "v3.0.1" });
            Assert.Equal("v3.0.1", (string)robot["imagemagick_stack"]);
            Assert.Null(robot["image_magick_stack"]);
        }

        [Fact]
        public void DateFormat_UsesTransloaditFormats()
        {
            var auth = Serialize(new AuthParams { Expires = new DateTime(2025, 2, 20, 1, 52, 4, DateTimeKind.Utc) });
            Assert.Equal("2025/02/20 01:52:04+00:00", (string)auth["expires"]);

            var pagination = Serialize(new PaginationParams { FromDate = new DateTime(2025, 2, 20, 1, 52, 4, DateTimeKind.Utc) });
            Assert.Equal("2025-02-20 01:52:04", (string)pagination["fromdate"]);
        }

        [Fact]
        public void PolymorphicSteps_SerializeByRuntimeType()
        {
            // steps are declared as Dictionary<string, RobotBase>; every serializer must emit the concrete robot's
            // parameters, not just the base-class members (System.Text.Json otherwise drops the derived properties).
            var request = new Transloadit.Models.Assemblies.AssemblyRequest
            {
                Steps = new Dictionary<string, RobotBase>
                {
                    ["resize"] = new ImageResizeRobot { Use = "in", Width = 120, ImageMagickStack = "v3.0.1" },
                },
            };

            var step = Serialize(request)["steps"]["resize"];

            Assert.Equal("/image/resize", (string)step["robot"]);
            Assert.Equal("in", (string)step["use"]);
            Assert.Equal(120, (int)step["width"]);
            Assert.Equal("v3.0.1", (string)step["imagemagick_stack"]);
        }

        [Fact]
        public void DateFormat_IsCultureInvariant()
        {
            // under a non-Gregorian locale (Thai Buddhist calendar) a culture-sensitive formatter would render the
            // year as 2568; the signed `expires` must always be invariant Gregorian regardless of the ambient culture
            var original = System.Threading.Thread.CurrentThread.CurrentCulture;
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
                var json = Serialize(new AuthParams { Expires = new DateTime(2025, 2, 20, 1, 52, 4, DateTimeKind.Utc) });
                Assert.Equal("2025/02/20 01:52:04+00:00", (string)json["expires"]);
            }
            finally
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = original;
            }
        }

        [Fact]
        public void NullValues_AreOmitted()
        {
            var json = Serialize(new ImageResizeRobot { ImageMagickStack = "v3.0.1" });
            Assert.Null(json["use"]);
            Assert.Null(json["output_meta"]);
            Assert.Null(json["ignore_errors"]);
        }
    }
}
