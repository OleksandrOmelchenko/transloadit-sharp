using System.Collections.Generic;

namespace Transloadit.Models.Robots.VideoEncoding
{
    /// <summary>
    /// Represents <c>/video/merge</c> Robot.
    /// </summary>
    public class VideoMergeRobot : RobotBase
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
        /// Generates the video according to pre-configured video presets. If you specify your own FFmpeg parameters using the Robot's <c>ffmpeg</c> 
        /// parameter and you have not specified a preset, then the default <c>flash</c> preset is not applied. This is to prevent you from having 
        /// to override each of the flash preset's values manually. One of <see cref="Constants.VideoEncodingPresetsV5"/> or
        /// <see cref="Constants.VideoEncodingPresetsV6"/>.
        /// </summary>
        public string Preset { get; set; }

        /// <summary>
        /// Width of the new video, in pixels. If the value is not specified and the preset parameter is available, the preset's supplied width 
        /// will be implemented. Value 1-1920.
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Height of the new video, in pixels. If the value is not specified and the preset parameter is available, the preset's supplied height 
        /// will be implemented. Value 1-1000.
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
        /// When merging images to generate a video this is the input framerate. A value of "1/5" means each image is given 5 seconds before the next 
        /// frame appears (the inverse of a framerate of "5"). Likewise for "1/10", "1/20", etc. A value of "5" means there are 5 frames per second.
        /// <para>Default: <c>1/5</c>.</para>
        /// </summary>
        public string Framerate { get; set; }

        /// <summary>
        /// When merging images to generate a video this allows you to define how long (in seconds) each image will be shown inside of the video. 
        /// So if you pass 3 images and define <c>[2.4, 5.6, 9]</c> the first image will be shown for 2.4s, the second image for 5.6s and the last one 
        /// for 9s. The <c>duration</c> parameter will automatically be set to the sum of the <c>image_durations</c>, so 17 in our example. 
        /// It can still be overwritten, though, in which case the last image will be shown until the defined duration is reached.
        /// </summary>
        public List<double> ImageDurations { get; set; }

        /// <summary>
        /// <list type="number">
        /// <item>When merging images to generate a video this is the desired target duration in seconds. The float value can take one decimal digit. 
        /// If you want all images to be displayed exactly once, then you can set the duration according to this formula: 
        /// <c>duration = numberOfImages / framerate</c>. This also works for the inverse framerate values like <c>1/5</c>.</item>
        /// <item>When merging audio and video this is the desired target duration in seconds. By default this takes the duration value of the 
        /// longest audio or video file.</item>
        /// <item>When merging images with an audio file, by default the duration of the input audio file will be used.</item>
        /// </list>
        /// <para>Default: Depends on the input.</para>
        /// </summary>
        public double? Duration { get; set; }

        /// <summary>
        /// When merging a video and an audio file, and when merging images and an audio file to generate a video, this is the desired delay in 
        /// seconds for the audio file to start playing. Imagine you merge a video file without sound and an audio file, but you wish the audio 
        /// to start playing after 5 seconds and not immediately, then this is the parameter to use.
        /// <para>Default: <c>0.0</c>.</para>
        /// </summary>
        public double? AudioDelay { get; set; }

        /// <summary>
        /// Determines whether the audio of the video should be replaced with a provided audio file.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? ReplaceAudio { get; set; }

        /// <summary>
        /// Stacks the input videos vertically instead. All streams need to have the same pixel format and width - so consider using a 
        /// <c>/video/encode</c> Step before using this parameter to enforce this.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? Vstack { get; set; }

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
        /// Initializes <c>/video/merge</c> Robot.
        /// </summary>
        public VideoMergeRobot()
        {
            Robot = "/video/merge";
        }
    }
}
