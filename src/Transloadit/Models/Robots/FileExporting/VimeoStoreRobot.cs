using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
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

        public VimeoStoreRobot()
        {
            Robot = "/vimeo/store";
        }
    }
}
