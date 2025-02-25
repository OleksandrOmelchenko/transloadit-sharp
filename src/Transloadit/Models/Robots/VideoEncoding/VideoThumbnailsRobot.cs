using System.Collections.Generic;

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

        /// <summary>
        /// The number of thumbnails to be extracted. As some videos have incorrect durations, the actual number of thumbnails generated may be less 
        /// in rare cases. The maximum number of thumbnails we currently allow is 999.
        /// <para>The thumbnails are taken at regular intervals, determined by dividing the video duration by the count. For example, a count 
        /// of 3 will produce thumbnails at 25%, 50% and 75% through the video.</para>
        /// <para>To extract thumbnails for specific timestamps, use the <c>offsets</c> parameter.</para>
        /// Value 1-999.
        /// <para>Default: <c>8</c>.</para>
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// An array of offsets representing seconds of the file duration, such as <c>[ 2, 45, 120 ]</c>. Millisecond durations of a file can also 
        /// be used by using decimal place values. For example, an offset from 1250 milliseconds would be represented with <c>1.25</c>. 
        /// Offsets can also be percentage values such as <c>[ "2%", "50%", "75%" ]</c>.
        /// <para>This option cannot be used with the count parameter, and takes precedence if both are specified. Out-of-range offsets 
        /// are silently ignored.</para>
        /// </summary>
        public AnyOf<List<int>, List<string>> Offsets { get; set; }

        /// <summary>
        /// The format of the extracted thumbnail. Supported values are <c>jpg</c>, <c>jpeg</c> and <c>png</c>. Even if you specify the format 
        /// to be <c>jpeg</c> the resulting thumbnails will have a <c>jpg</c> file extension.
        /// <para>Default: <c>jpeg</c>.</para>
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// The width of the thumbnail, in pixels. Value 1-1920.
        /// <para>Default: Width of the video.</para>
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// The height of the thumbnail, in pixels. Value 1-1080.
        /// <para>Default: Height of the video.</para>
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Image resize strategy. One of <see cref="Constants.ResizeStrategy"/>: <c>fit</c>, <c>fillcrop</c>, <c>min_fit</c>, 
        /// <c>pad</c>, <c>stretch</c> and <c>crop</c>.
        /// <para>Default: <c>pad</c>.</para>
        /// </summary>
        public string ResizeStrategy { get; set; }

        /// <summary>
        /// The background color of the resulting video the "rrggbbaa" format (red, green, blue, alpha) when used with the <c>pad</c> resize strategy. 
        /// The default color is black.
        /// <para>Default: <c>00000000</c>.</para>
        /// </summary>
        public string Background { get; set; }

        /// <summary>
        /// Forces the video to be rotated by the specified degree integer. Currently, only multiples of 90 are supported. We automatically
        /// correct the orientation of many videos when the orientation is provided by the camera. This option is only useful for videos
        /// requiring rotation because it was not detected by the camera.
        /// <para>Default: auto.</para>
        /// </summary>
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
