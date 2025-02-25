using System.Collections.Generic;
using Transloadit.Models.Robots.ImageManipulation;

namespace Transloadit.Models.Robots.VideoEncoding
{
    /// <summary>
    /// Represents <c>/video/encode</c> Robot.
    /// </summary>
    public class VideoEncodeRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }
        public string Preset { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string ResizeStrategy { get; set; }
        public bool? Zoom { get; set; }
        public AnyOf<string, Crop> Crop { get; set; }
        public string Background { get; set; }
        public int? Rotate { get; set; }
        public bool? Hint { get; set; }
        public bool? Turbo { get; set; }
        public int? ChunkDuration { get; set; }
        public bool? FreezeDetect { get; set; }

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
        /// Initializes <c>/video/encode</c> Robot.
        /// </summary>
        public VideoEncodeRobot()
        {
            Robot = "/video/encode";
        }
    }
}
