using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.AudioEncoding
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/audio-merge/">/audio/merge</a> Robot.
    /// </summary>
    public class AudioMergeRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [JsonProperty("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Performs conversion using pre-configured settings. If you specify your own FFmpeg parameters using the Robot's ffmpeg parameter 
        /// and you have not specified a preset, then the default mp3 preset is not applied. This is to prevent you from having to override 
        /// each of the MP3 preset's values manually. One of <see cref="Constants.AudioEncodingPresetsV5"/> 
        /// or <see cref="Constants.AudioEncodingPresetsV6"/>.
        /// </summary>
        [JsonProperty("preset")]
        public string Preset { get; set; }

        /// <summary>
        /// Bit rate of the resulting audio file, in bits per second. If not specified will default to the bit rate of the input audio file.
        /// </summary>
        [JsonProperty("bitrate")]
        public int? Bitrate { get; set; }

        /// <summary>
        /// Sample rate of the resulting audio file, in Hertz. If not specified will default to the sample rate of the input audio file.
        /// </summary>
        [JsonProperty("sample_rate")]
        public int? SampleRate { get; set; }

        /// <summary>
        /// Duration of the output file compared to the duration of all merged audio files. Can be <c>first</c> (duration of the first input file), 
        /// <c>shortest</c> (duration of the shortest audio file) or <c>longest</c> for the duration of the longest input file.
        /// <para>Default: <c>longest</c>.</para>
        /// </summary>
        [JsonProperty("duration")]
        public string Duration { get; set; }

        /// <summary>
        /// Specifies if any input files that do not match the target duration should be looped to match it. Useful for audio merging 
        /// where your overlay file is typically much shorter than the main audio file.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        [JsonProperty("loop")]
        public bool? Loop { get; set; }

        /// <summary>
        /// Valid values are <c>average</c> and <c>sum</c> here. <c>average</c> means each input is scaled 1/n (n is the number of inputs) 
        /// or <c>sum</c> which means each individual audio stays on the same volume, but since we merge tracks 'on top' of each other, 
        /// this could result in very loud output.
        /// <para>Default: <c>average</c>.</para>
        /// </summary>
        [JsonProperty("volume")]
        public string Volume { get; set; }

        /// <summary>
        /// FFmpeg stack version. One of <see cref="Constants.FFMpegStack"/>: <c>v5.0.0</c> or <c>v6.0.0</c>.
        /// <para>Default: <c>v5.0.0</c>.</para>
        /// </summary>
        [JsonProperty("ffmpeg_stack")]
        public string FfmpegStack { get; set; }

        /// <summary>
        /// A parameter object to be passed to FFmpeg. If a preset is used, the options specified are merged on top of the ones from the preset. 
        /// For available options, see the <a href="https://ffmpeg.org/ffmpeg-doc.html">FFmpeg documentation</a>. 
        /// Options specified here take precedence over the preset options.
        /// </summary>
        [JsonProperty("ffmpeg")]
        public Dictionary<string, object> Ffmpeg { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/audio-merge/">/audio/merge</a> Robot.
        /// </summary>
        public AudioMergeRobot()
        {
            Robot = "/audio/merge";
        }
    }
}
