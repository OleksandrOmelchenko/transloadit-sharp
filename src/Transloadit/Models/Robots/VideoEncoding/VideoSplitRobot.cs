using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.VideoEncoding
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/video-split/">/video/split</a> Robot.
    /// </summary>
    public class VideoSplitRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [TransloaditJsonName("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// FFmpeg options merged over preset options.
        /// </summary>
        [TransloaditJsonName("ffmpeg")]
        public Dictionary<string, object> Ffmpeg { get; set; }

        /// <summary>
        /// FFmpeg stack version.
        /// </summary>
        [TransloaditJsonName("ffmpeg_stack")]
        public string FfmpegStack { get; set; }

        /// <summary>
        /// Optional preset.
        /// </summary>
        [TransloaditJsonName("preset")]
        public string Preset { get; set; }

        /// <summary>
        /// Output width in pixels.
        /// </summary>
        [TransloaditJsonName("width")]
        public AnyOf<int, string> Width { get; set; }

        /// <summary>
        /// Output height in pixels.
        /// </summary>
        [TransloaditJsonName("height")]
        public AnyOf<int, string> Height { get; set; }

        /// <summary>
        /// Video segments to extract.
        /// </summary>
        [TransloaditJsonName("segments")]
        public List<VideoSplitSegment> Segments { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/video-split/">/video/split</a> Robot.
        /// </summary>
        public VideoSplitRobot()
        {
            Robot = "/video/split";
        }
    }

    /// <summary>
    /// Represents a video split segment.
    /// </summary>
    public class VideoSplitSegment
    {
        /// <summary>
        /// Segment start offset.
        /// </summary>
        [TransloaditJsonName("from")]
        public AnyOf<int, string> From { get; set; }

        /// <summary>
        /// Segment end offset.
        /// </summary>
        [TransloaditJsonName("to")]
        public AnyOf<int, string> To { get; set; }
    }
}
