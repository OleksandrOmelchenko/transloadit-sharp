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
        public string Preset { get; set; }
        public string SubtitlesType { get; set; }
        public string BorderStyle { get; set; }
        public string BorderColor { get; set; }
        public string Font { get; set; }
        public string FontColor { get; set; }
        public int? FontSize { get; set; }
        public string Position { get; set; }
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
