using System.Collections.Generic;

namespace Transloadit.Models.Robots.AudioEncoding
{
    /// <summary>
    /// Represents <c>/audio/loop</c> Robot.
    /// </summary>
    public class AudioLoopRobot : RobotBase
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
        /// Performs conversion using pre-configured settings. If you specify your own FFmpeg parameters using the Robot's ffmpeg parameter 
        /// and you have not specified a preset, then the default mp3 preset is not applied. This is to prevent you from having to override 
        /// each of the MP3 preset's values manually. One of <see cref="Constants.AudioEncodingPresetsV5"/> 
        /// or <see cref="Constants.AudioEncodingPresetsV6"/>.
        /// </summary>
        public string Preset { get; set; }

        /// <summary>
        /// Bit rate of the resulting audio file, in bits per second. If not specified will default to the bit rate of the input audio file.
        /// </summary>
        public int? Bitrate { get; set; }

        /// <summary>
        /// Sample rate of the resulting audio file, in Hertz. If not specified will default to the sample rate of the input audio file.
        /// </summary>
        public int? SampleRate { get; set; }

        /// <summary>
        /// Target duration for the whole process in seconds. The Robot will loop the input audio file for as long as this target duration is not reached yet.
        /// <para>Default: <c>60.0</c>.</para>
        /// </summary>
        public double? Duration { get; set; }

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
        /// Initializes <c>/audio/loop</c> Robot.
        /// </summary>
        public AudioLoopRobot()
        {
            Robot = "/audio/loop";
        }
    }
}
