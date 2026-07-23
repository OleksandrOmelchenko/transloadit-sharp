using Transloadit.Serialization.Attributes;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/vimeo-import/">/vimeo/import</a> Robot.
    /// </summary>
    public class VimeoImportRobot : ImportRobotBase
    {
        /// <summary>
        /// Page number for paginated imports.
        /// </summary>
        [TransloaditJsonName("page_number")]
        public int? PageNumber { get; set; }

        /// <summary>
        /// Number of files to import per page.
        /// </summary>
        [TransloaditJsonName("files_per_page")]
        public int? FilesPerPage { get; set; }

        /// <summary>
        /// Requested rendition quality. One of <see cref="Constants.VimeoRenditions"/>.
        /// </summary>
        [TransloaditJsonName("rendition")]
        public string Rendition { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/vimeo-import/">/vimeo/import</a> Robot.
        /// </summary>
        public VimeoImportRobot()
        {
            Robot = "/vimeo/import";
        }
    }
}
