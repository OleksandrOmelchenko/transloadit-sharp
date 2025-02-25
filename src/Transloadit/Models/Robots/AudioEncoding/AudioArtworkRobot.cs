using System.Collections.Generic;

namespace Transloadit.Models.Robots.AudioEncoding
{
    /// <summary>
    /// Represents <c>/audio/artwork</c> Robot.
    /// </summary>
    public class AudioArtworkRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// What should be done with the audio file. A value of <c>extract</c> means audio artwork will be extracted. 
        /// A value of <c>insert</c> means the provided image will be inserted as audio artwork.
        /// <para>Default: <c>extract</c>.</para>
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Whether the original file should be transcoded into a new format if there is an issue with the original file.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? ChangeFormatIfNecessary { get; set; }

        /// <summary>
        /// FFmpeg stack version. One of <see cref="Constants.FFMpegStack"/>: <c>v5.0.0</c> or <c>v6.0.0</c>.
        /// <para>Default: <c>v5.0.0</c>.</para>
        /// </summary>
        public string FfmpegStack { get; set; }

        /// <summary>
        /// Initializes <c>/audio/artwork</c> Robot.
        /// </summary>
        public AudioArtworkRobot()
        {
            Robot = "/audio/artwork";
        }
    }
}
