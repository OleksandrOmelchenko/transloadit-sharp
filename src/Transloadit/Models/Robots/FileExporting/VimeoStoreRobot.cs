using Transloadit.Serialization.Attributes;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/vimeo-store/">/vimeo/store</a> Robot.
    /// </summary>
    public class VimeoStoreRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [TransloaditJsonName("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Template credentials name.
        /// </summary>
        [TransloaditJsonName("credentials")]
        public string Credentials { get; set; }

        /// <summary>
        /// The title of the video to be displayed on Vimeo.
        /// </summary>
        [TransloaditJsonName("title")]
        public string Title { get; set; }

        /// <summary>
        /// The description of the video to be displayed on Vimeo.
        /// </summary>
        [TransloaditJsonName("description")]
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
        [TransloaditJsonName("acl")]
        public string Acl { get; set; }

        /// <summary>
        /// The password to access the video if acl is <c>password</c>.
        /// </summary>
        [TransloaditJsonName("password")]
        public string Password { get; set; }

        /// <summary>
        /// An array of string IDs of showcases that you want to add the video to. The IDs can be found when browsing Vimeo. 
        /// </summary>
        [TransloaditJsonName("showcases")]
        public List<string> Showcases { get; set; }

        /// <summary>
        /// Whether or not the video can be downloaded from the Vimeo website.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        [TransloaditJsonName("downloadable")]
        public bool? Downloadable { get; set; }

        /// <summary>
        /// The ID of the folder to which the video is uploaded.
        /// </summary>
        [TransloaditJsonName("folder_id")]
        public string FolderId { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/vimeo-store/">/vimeo/store</a> Robot.
        /// </summary>
        public VimeoStoreRobot()
        {
            Robot = "/vimeo/store";
        }
    }
}
