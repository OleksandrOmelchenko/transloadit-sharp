using System.Collections.Generic;

namespace Transloadit.Models.Robots.AudioEncoding
{
    /// <summary>
    /// Represents <c>/audio/concat</c> Robot.
    /// </summary>
    public class AudioConcatenateRobot : RobotBase
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
        public int? Bitrate { get; set; }
        public int? SampleRate { get; set; }
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
        /// Initializes <c>/audio/concat</c> Robot.
        /// </summary>
        public AudioConcatenateRobot()
        {
            Robot = "/audio/concat";
        }
    }
}
