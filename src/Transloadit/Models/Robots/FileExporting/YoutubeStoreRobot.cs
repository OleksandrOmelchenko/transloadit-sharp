using System.Collections.Generic;
using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/youtube-store/">/youtube/store</a> Robot.
    /// </summary>
    public class YoutubeStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [JsonProperty("use")]
        public new AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Template credentials name.
        /// </summary>
        [JsonProperty("credentials")]
        public new string Credentials { get; set; }

        /// <summary>
        /// The title of the video to be displayed on YouTube. Note that since the YouTube API requires titles to be within 80 characters, 
        /// longer titles may be truncated.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// The description of the video to be displayed on YouTube. This can be up to 5000 characters, including <c>\n</c> for new-lines.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The category to which this video will be assigned. These are the valid values: <c>autos &amp; vehicles</c>, <c>comedy</c>, <c>education</c>, <c>entertainment</c>, <c>film &amp; animation</c>, <c>gaming</c>, <c>howto &amp; style</c>, <c>music</c>, <c>news &amp; politics</c>, <c>people &amp; blogs</c>, <c>pets &amp; animals</c>, <c>science &amp; technology</c>, <c>sports</c>, <c>travel &amp; events</c>.
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; set; }

        /// <summary>
        /// Tags used to describe the video, separated by commas. These tags will also be displayed on YouTube.
        /// </summary>
        [JsonProperty("keywords")]
        public string Keywords { get; set; }

        /// <summary>
        /// Defines the visibility of the uploaded video.
        /// </summary>
        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/youtube-store/">/youtube/store</a> Robot.
        /// </summary>
        public YoutubeStoreRobot()
        {
            Robot = "/youtube/store";
        }
    }
}
