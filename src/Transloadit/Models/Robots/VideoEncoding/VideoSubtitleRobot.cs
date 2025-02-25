using System.Collections.Generic;

namespace Transloadit.Models.Robots.VideoEncoding
{
    /// <summary>
    /// Represents <c>/video/subtitle</c> Robot.
    /// </summary>
    public class VideoSubtitleRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Allows to specify a set of metadata that is more expensive on CPU power to calculate, 
        /// and thus is disabled by default to keep your Assemblies processing fast.
        /// This can be set to <c>false</c> to skip metadata extraction and speed up transcoding.
        /// <para>Default: <c>{}</c>.</para>
        /// </summary>
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }

        /// <summary>
        /// Performs conversion using pre-configured settings. By default, no settings are applied and the original settings of the video are preserved.
        /// One of <see cref="Constants.VideoEncodingPresetsV5"/> or <see cref="Constants.VideoEncodingPresetsV6"/>.
        /// <para>Default: <c>empty</c>.</para>
        /// </summary>
        public string Preset { get; set; }

        /// <summary>
        /// Determines if subtitles are added as a separate stream to the video (value <c>external</c>) that then can be switched on and off in your 
        /// video player, or if they should be burned directly into the video (value <c>burn</c>) so that they become part of the video stream.
        /// <para>Default: <c>external</c>.</para>
        /// </summary>
        public string SubtitlesType { get; set; }

        /// <summary>
        /// Specifies the style of the subtitle. Use the <c>border_color</c> parameter to specify the color of the border.
        /// <para>Default: <c>outline</c>.</para>
        /// </summary>
        public string BorderStyle { get; set; }

        /// <summary>
        /// The color for the subtitle border. The first two hex digits specify the alpha value of the color.
        /// <para>Default: <c>40000000</c>.</para>
        /// </summary>
        public string BorderColor { get; set; }

        /// <summary>
        /// The font family to use. Also includes boldness and style of the font. One of <see cref="Constants.Fonts"/>.
        /// <para>Default: <c>Arial</c>.</para>
        /// </summary>
        public string Font { get; set; }

        /// <summary>
        /// The color of the subtitle text. The first two hex digits specify the alpha value of the color.
        /// <para>Default: <c>00FFFFFF</c>.</para>
        /// </summary>
        public string FontColor { get; set; }

        /// <summary>
        /// Specifies the size of the text.
        /// <para>Default: <c>16</c>.</para>
        /// </summary>
        public int? FontSize { get; set; }

        /// <summary>
        /// Specifies the position of the subtitles. The available options are <c>center</c>, <c>top</c>, <c>bottom</c>, <c>left</c>, and 
        /// <c>right</c>. You can also combine options, such as <c>bottom-right</c>.
        /// <para>Default: <c>bottom</c>.</para>
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// FFmpeg stack version. One of <see cref="Constants.FFMpegStack"/>: <c>v5.0.0</c> or <c>v6.0.0</c>.
        /// <para>Default: <c>v5.0.0</c>.</para>
        /// </summary>
        public string FfmpegStack { get; set; }

        /// <summary>
        /// A parameter object to be passed to FFmpeg. If a preset is used, the options specified are merged on top of the ones from the preset. 
        /// For available options, see the <a href="https://ffmpeg.org/ffmpeg-doc.html">FFmpeg documentation</a>. 
        /// Options specified here take precedence over the preset options.
        /// </summary>
        public Dictionary<string, object> Ffmpeg { get; set; }

        /// <summary>
        /// Initializes <c>/video/subtitle</c> Robot.
        /// </summary>
        public VideoSubtitleRobot()
        {
            Robot = "/video/subtitle";
        }
    }
}
