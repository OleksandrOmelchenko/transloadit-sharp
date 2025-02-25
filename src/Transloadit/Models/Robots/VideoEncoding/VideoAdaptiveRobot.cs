using System.Collections.Generic;

namespace Transloadit.Models.Robots.VideoEncoding
{
    /// <summary>
    /// Represents <c>/video/adaptive</c> Robot.
    /// </summary>
    public class VideoAdaptiveRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Determines which streaming technique should be used. Currently supports <c>dash</c> for MPEG-Dash and <c>hls</c> for HTTP Live Streaming.
        /// <para>Default: <c>dash</c>.</para>
        /// </summary>
        public string Technique { get; set; }

        /// <summary>
        /// The filename for the generated manifest/playlist file. The default is <c>playlist.mpd</c> if your technique is <c>dash</c>, and 
        /// <c>playlist.m3u8</c> if your technique is <c>hls</c>.
        /// <para>Default: <c>playlist.mpd</c>.</para>
        /// </summary>
        public string PlaylistName { get; set; }

        /// <summary>
        /// The duration for each segment in seconds.
        /// <para>Default: <c>10</c>.</para>
        /// </summary>
        public int? SegmentDuration { get; set; }

        /// <summary>
        /// Determines whether you want closed caption support when using the <c>hls</c> technique.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        public bool? ClosedCaptions { get; set; }

        /// <summary>
        /// Initializes <c>/video/adaptive</c> Robot.
        /// </summary>
        public VideoAdaptiveRobot()
        {
            Robot = "/video/adaptive";
        }
    }
}
