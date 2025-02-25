﻿using System.Collections.Generic;

namespace Transloadit.Models.Robots.VideoEncoding
{
    /// <summary>
    /// Represents <c>/video/thumbs</c> Robot.
    /// </summary>
    public class VideoThumbnailsRobot : RobotBase
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
        public int? Count { get; set; }
        public AnyOf<List<int>, List<string>> Offsets { get; set; }
        public string Format { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string ResizeStrategy { get; set; }
        public string Background { get; set; }
        public int? Rotate { get; set; }

        /// <summary>
        /// FFmpeg stack version. One of <see cref="Constants.FFMpegStack"/>: <c>v5.0.0</c> or <c>v6.0.0</c>.
        /// <para>Default: <c>v5.0.0</c>.</para>
        /// </summary>
        public string FfmpegStack { get; set; }

        /// <summary>
        /// Initializes <c>/video/thumbs</c> Robot.
        /// </summary>
        public VideoThumbnailsRobot()
        {
            Robot = "/video/thumbs";
        }
    }
}
