using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/vimeo/store</c> Robot.
    /// </summary>
    public class VimeoStoreRobot : RobotBase
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
        /// The title of the video to be displayed on Vimeo.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The description of the video to be displayed on Vimeo.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Controls access permissions for the video. Here are the valid values:
        /// <list type="bullet">
        /// <item><c>anybody</c> - anyone can access the video.</item>
        /// <item><c>contacts</c> - only those who follow the owner on Vimeo can access the video.</item>
        /// <item><c>disable</c> - the video is embeddable, but it's hidden on Vimeo and can't be played.</item>
        /// <item><c>nobody</c> - no one except the owner can access the video.</item>
        /// <item><c>password</c> - only those with the password can access the video.</item>
        /// <item><c>unlisted</c> - only those with the private link can access the video.</item>
        /// <item><c>users</c> - only Vimeo members can access the video.</item>
        /// </list>
        /// <para>Default: <c>anybody</c>.</para>
        /// </summary>
        public string Acl { get; set; }

        /// <summary>
        /// The password to access the video if acl is <c>password</c>.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// An array of string IDs of showcases that you want to add the video to. The IDs can be found when browsing Vimeo. 
        /// </summary>
        public List<string> Showcases { get; set; }

        /// <summary>
        /// Whether or not the video can be downloaded from the Vimeo website.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? Downloadable { get; set; }

        /// <summary>
        /// The ID of the folder to which the video is uploaded.
        /// </summary>
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
