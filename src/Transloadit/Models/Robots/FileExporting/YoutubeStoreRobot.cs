using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/youtube/store</c> Robot.
    /// </summary>
    public class YoutubeStoreRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Credentials { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Keywords { get; set; }
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
