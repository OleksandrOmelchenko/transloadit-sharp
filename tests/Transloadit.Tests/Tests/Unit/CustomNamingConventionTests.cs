using Newtonsoft.Json.Linq;
using Transloadit.Serialization;
using Transloadit.Serialization.Attributes;
using Transloadit.Tests.Infrastructure;
using Xunit;

#if TRANSLOADIT_NEWTONSOFT
using Newtonsoft.Json.Serialization;
#else
using System.Text.Json;
#endif

namespace Transloadit.Tests.Tests.Unit;

// the built-in serializers apply no naming convention, so a model must declare its JSON names. callers who prefer
// convention-based naming for their own models can opt in through the adapter's configure callback — these tests
// demonstrate that escape hatch and prove the neutral attributes still take precedence over the convention.
public class CustomNamingConventionTests
{
    // deliberately unannotated, standing in for a user model that relies on a naming convention
    private sealed class ConventionOnlyModel
    {
        public string ResizeStrategy { get; set; }

        public int ImageWidth { get; set; }
    }

    // mixes an explicit name with a convention-derived one
    private sealed class MixedNamingModel
    {
        [TransloaditJsonName("imagemagick_stack")]
        public string ImageMagickStack { get; set; }

        public string ResizeStrategy { get; set; }
    }

    private static ITransloaditSerializer SnakeCaseSerializer()
    {
#if TRANSLOADIT_NEWTONSOFT
        return new NewtonsoftJsonSerializer(settings =>
            ((DefaultContractResolver)settings.ContractResolver).NamingStrategy = new SnakeCaseNamingStrategy());
#else
        return new SystemTextJsonSerializer(options => options.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower);
#endif
    }

    [Fact]
    public void WithoutCustomSetup_UnannotatedPropertiesKeepTheirClrNames()
    {
        var json = JObject.Parse(TestSerializer.Default.Serialize(
            new ConventionOnlyModel { ResizeStrategy = "fit", ImageWidth = 5 }));

        Assert.Equal("fit", (string)json["ResizeStrategy"]);
        Assert.Equal(5, (int)json["ImageWidth"]);
        Assert.Null(json["resize_strategy"]);
    }

    [Fact]
    public void WithSnakeCaseSetup_UnannotatedPropertiesAreConverted()
    {
        var json = JObject.Parse(SnakeCaseSerializer().Serialize(
            new ConventionOnlyModel { ResizeStrategy = "fit", ImageWidth = 5 }));

        Assert.Equal("fit", (string)json["resize_strategy"]);
        Assert.Equal(5, (int)json["image_width"]);
        Assert.Null(json["ResizeStrategy"]);
    }

    [Fact]
    public void WithSnakeCaseSetup_ExplicitNamesStillWin()
    {
        var json = JObject.Parse(SnakeCaseSerializer().Serialize(
            new MixedNamingModel { ImageMagickStack = "v3.0.1", ResizeStrategy = "fit" }));

        // the attribute wins over the convention (snake_case would have produced "image_magick_stack")
        Assert.Equal("v3.0.1", (string)json["imagemagick_stack"]);
        Assert.Null(json["image_magick_stack"]);

        // the unannotated property still follows the opted-in convention
        Assert.Equal("fit", (string)json["resize_strategy"]);
    }
}
