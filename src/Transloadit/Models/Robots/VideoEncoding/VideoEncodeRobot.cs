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

        /// <summary>
        /// Allows to specify a set of metadata that is more expensive on CPU power to calculate, 
        /// and thus is disabled by default to keep your Assemblies processing fast.
        /// This can be set to <c>false</c> to skip metadata extraction and speed up transcoding.
        /// <para>Default: <c>{}</c>.</para>
        /// </summary>
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }

        /// <summary>
        /// Converts a video according to pre-configured settings. If you specify your own FFmpeg parameters using the Robot's and/or do not 
        /// want Transloadit to set any encoding setting, starting <c>ffmpeg_stack: "v6.0.0"</c>, you can use the value <c>empty</c> here.
        /// One of <see cref="Constants.VideoEncodingPresetsV5"/> or <see cref="Constants.VideoEncodingPresetsV6"/>.
        /// <para>Default: <c>flash</c>.</para>
        /// </summary>
        public string Preset { get; set; }

        /// <summary>
        /// Width of the new video, in pixels. Value 1-1920. If the value is not specified and the preset parameter is available, the preset's supplied width will be implemented.
        /// <para>Default: Width of the input video .</para>
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Height of the new video, in pixels. Value 1-1080. If the value is not specified and the preset parameter is available, the preset's supplied height will be implemented.
        /// <para>Default: Height of the input video.</para>
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Image resize strategy. One of <see cref="Constants.ResizeStrategy"/>: <c>fit</c>, <c>fillcrop</c>, <c>min_fit</c>, 
        /// <c>pad</c>, <c>stretch</c> and <c>crop</c>.
        /// <para>Default: <c>pad</c>.</para>
        /// </summary>
        public string ResizeStrategy { get; set; }

        /// <summary>
        /// If this is set to <c>false</c>, smaller videos will not be stretched to the desired width and height. For details about the impact 
        /// of zooming for your preferred resize strategy, see the list of available 
        /// <a href="https://transloadit.com/docs/transcoding/image-manipulation/image-resize/#resize-strategies">resize strategies</a>.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        public bool? Zoom { get; set; }

        /// <summary>
        /// Specify an object containing coordinates for the top left and bottom right corners of the rectangle to be cropped from the original 
        /// video(s). Values can be integers for absolute pixel values or strings for percentage based values. For example: 
        /// <code>
        /// 
        /// {
        ///   "x1": 80,
        ///   "y1": 100,
        ///   "x2": "60%",
        ///   "y2": "80%"
        /// }
        /// </code>
        /// This will crop the area from (80, 100) to (600, 800) from a 1000×1000 pixels video, which is a square whose width is 520px and height 
        /// is 700px. If crop is set, the width and height parameters are ignored, and the resize_strategy is set to crop automatically.
        /// <para>You can also use a JSON string of such an object with coordinates in similar fashion: 
        /// <c>{ \"x1\": int, \"y1\": int, \"x2\": int, \"y2\": int }</c></para>
        /// <para>Default: <c>null</c>.</para>
        /// </summary>
        public AnyOf<string, Crop> Crop { get; set; }

        /// <summary>
        /// The background color of the resulting video the "rrggbbaa" format (red, green, blue, alpha) when used with the <c>pad</c> resize strategy. 
        /// The default color is black.
        /// <para>Default: <c>00000000</c>.</para>
        /// </summary>
        public string Background { get; set; }

        /// <summary>
        /// Forces the video to be rotated by the specified degree integer. Currently, only multiples of <c>90</c> are supported. We automatically 
        /// correct the orientation of many videos when the orientation is provided by the camera. This option is only useful for videos 
        /// requiring rotation because it was not detected by the camera. If you set <c>rotate</c> to <c>false</c> no rotation is performed, even 
        /// if the metadata contains such instructions. Values <c>0</c>, <c>90</c>, <c>180</c>, <c>270</c>, <c>360</c>.
        /// <para>Default: auto.</para>
        /// </summary>
        public AnyOf<bool, int> Rotate { get; set; }

        /// <summary>
        /// Enables hinting for mp4 files, for RTP/RTSP streaming.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? Hint { get; set; }

        /// <summary>
        /// Splits the video into multiple chunks so that each chunk can be encoded in parallel before all encoded chunks are stitched back 
        /// together to form the result video. This comes at the expense of extra Priority Job Slots and may prove to be counter-productive 
        /// for very small video files.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? Turbo { get; set; }

        /// <summary>
        /// Allows you to specify the duration of each chunk when <c>turbo</c> is set to <c>true</c>. This means you can take advantage of that 
        /// feature while using fewer Priority Job Slots. For instance, the longer each chunk is, the fewer Encoding Jobs will need to be used.
        /// <para>Default: auto.</para>
        /// </summary>
        public int? ChunkDuration { get; set; }

        /// <summary>
        /// Examines the transcoding result file for video freeze frames and re-transcodes the video a second time if they are found. This is 
        /// useful when you are using <c>turbo: true</c> because freeze frames can sometimes happen there. The re-transcode would then happen 
        /// without turbo mode.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
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
