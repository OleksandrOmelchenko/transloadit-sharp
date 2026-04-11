using Transloadit.Constants;
using Transloadit.Models.Robots;
using Transloadit.Models.Robots.AI;
using Transloadit.Models.Robots.AudioEncoding;
using Transloadit.Models.Robots.Documents;
using Transloadit.Models.Robots.FileExporting;
using Transloadit.Models.Robots.FileImporting;
using Transloadit.Models.Robots.ImageManipulation;
using Transloadit.Models.Robots.SmartCdn;
using Transloadit.Models.Robots.VideoEncoding;
using Xunit;

namespace Transloadit.Tests.Tests
{
    public class NewRobotsTests
    {
        [Fact]
        public void NewRobotConstructors_Should_SetRobotPaths()
        {
            Assert.Equal("/ai/chat", new AiChatRobot().Robot);
            Assert.Equal("/video/generate", new VideoGenerateRobot().Robot);
            Assert.Equal("/audio/split", new AudioSplitRobot().Robot);
            Assert.Equal("/document/optimize", new DocumentOptimizeRobot().Robot);
            Assert.Equal("/box/import", new BoxImportRobot().Robot);
            Assert.Equal("/box/store", new BoxStoreRobot().Robot);
            Assert.Equal("/vimeo/import", new VimeoImportRobot().Robot);
            Assert.Equal("/image/upscale", new ImageUpscaleRobot().Robot);
            Assert.Equal("/tlcdn/deliver", new TlcdnDeliverRobot().Robot);
            Assert.Equal("/video/artwork", new VideoArtworkRobot().Robot);
            Assert.Equal("/video/ondemand", new VideoOndemandRobot().Robot);
            Assert.Equal("/video/split", new VideoSplitRobot().Robot);
        }

        [Fact]
        public void NewConstants_Should_HaveExpectedValues()
        {
            Assert.Equal("screen", DocumentOptimizePresets.Screen);
            Assert.Equal("ebook", DocumentOptimizePresets.Ebook);
            Assert.Equal("printer", DocumentOptimizePresets.Printer);
            Assert.Equal("prepress", DocumentOptimizePresets.Prepress);

            Assert.Equal("nightmareai/real-esrgan", ImageUpscaleModels.RealEsrgan);
            Assert.Equal("tencentarc/gfpgan", ImageUpscaleModels.Gfpgan);
            Assert.Equal("sczhou/codeformer", ImageUpscaleModels.Codeformer);

            Assert.Equal("240p", VimeoRenditions.P240);
            Assert.Equal("360p", VimeoRenditions.P360);
            Assert.Equal("540p", VimeoRenditions.P540);
            Assert.Equal("720p", VimeoRenditions.P720);
            Assert.Equal("1080p", VimeoRenditions.P1080);
            Assert.Equal("source", VimeoRenditions.Source);

            Assert.Equal("openai", AIProviders.OpenAi);
            Assert.Equal("anthropic", AIProviders.Anthropic);
            Assert.Equal("google", AIProviders.Google);
        }
    }
}
