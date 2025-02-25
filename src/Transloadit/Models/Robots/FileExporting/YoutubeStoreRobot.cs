using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/youtube/store</c> Robot.
    /// </summary>
    public class YoutubeStoreRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Template credentials name.
        /// </summary>
        public string Credentials { get; set; }

        /// <summary>
        /// The title of the video to be displayed on YouTube. Note that since the YouTube API requires titles to be within 80 characters, 
        /// longer titles may be truncated.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The description of the video to be displayed on YouTube. This can be up to 5000 characters, including <c>\n</c> for new-lines.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The category to which this video will be assigned. These are the valid values: <c>autos &amp; vehicles</c>, <c>comedy</c>, <c>education</c>, <c>entertainment</c>, <c>film &amp; animation</c>, <c>gaming</c>, <c>howto &amp; style</c>, <c>music</c>, <c>news &amp; politics</c>, <c>people &amp; blogs</c>, <c>pets &amp; animals</c>, <c>science &amp; technology</c>, <c>sports</c>, <c>travel &amp; events</c>.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Tags used to describe the video, separated by commas. These tags will also be displayed on YouTube.
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// Defines the visibility of the uploaded video.
        /// </summary>
        public string Visibility { get; set; }

        /// <summary>
        /// Initializes <c>/youtube/store</c> Robot.
        /// </summary>
        public YoutubeStoreRobot()
        {
            Robot = "/youtube/store";
        }
    }
}
