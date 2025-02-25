using System.Collections.Generic;

namespace Transloadit.Models.Robots.VideoEncoding
{
    /// <summary>
    /// Represents <c>/video/concat</c> Robot.
    /// </summary>
    public class VideoConcatenateRobot : RobotBase
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
        /// Performs conversion using pre-configured settings. If you specify your own FFmpeg parameters using the Robot's <c>ffmpeg</c> parameter 
        /// and you have not specified a preset, then the default <c>flash</c> preset is not applied. This is to prevent you from having to override 
        /// each of the flash preset's values manually. One of <see cref="Constants.VideoEncodingPresetsV5"/> or
        /// <see cref="Constants.VideoEncodingPresetsV6"/>.
        /// <para>Default: <c>flash</c>.</para>
        /// </summary>
        public string Preset { get; set; }

        /// <summary>
        /// When used this adds a video fade in and out effect between each section of your concatenated video. The float value is used so if you want a video delay effect of 500 milliseconds between each video section you would select 0.5, however, integer values can also be represented. This parameter does not add a video fade effect at the beginning or end of your video. Please note this parameter is independent of adding audio fades between sections.
        /// <para>Default: <c>1.0</c>.</para>
        /// </summary>
        public double? VideoFadeSeconds { get; set; }

        /// <summary>
        /// When used this adds an audio fade in and out effect between each section of your concatenated video. The float value is used so if you want an audio delay effect of 500 milliseconds between each video section you would select 0.5, however, integer values can also be represented. This parameter does not add an audio fade effect at the beginning or end of your video. Please note this parameter is independent of adding video fades between sections.
        /// <para>Default: <c>1.0</c>.</para>
        /// </summary>
        public double? AudioFadeSeconds { get; set; }

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
        /// Initializes <c>/video/concat</c> Robot.
        /// </summary>
        public VideoConcatenateRobot()
        {
            Robot = "/video/concat";
        }
    }
}
