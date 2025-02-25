using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/vimeo/store</c> Robot.
    /// </summary>
    public class VimeoStoreRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Credentials { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Acl { get; set; }
        public string Password { get; set; }
        public List<string> Showcases { get; set; }
        public bool? Downloadable { get; set; }
        public string FolderId { get; set; }

        /// <summary>
        /// Initializes <c>/vimeo/store</c> Robot.
        /// </summary>
        public VimeoStoreRobot()
        {
            Robot = "/vimeo/store";
        }
    }
}
