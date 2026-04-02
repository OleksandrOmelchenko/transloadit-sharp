using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/vimeo/import</c> Robot.
    /// </summary>
    public class VimeoImportRobot : ImportRobotBase
    {
        /// <summary>
        /// Custom name for imported files.
        /// </summary>
        [JsonProperty("force_name")]
        public AnyOf<string, List<string>> ForceName { get; set; }

        /// <summary>
        /// Page number for paginated imports.
        /// </summary>
        [JsonProperty("page_number")]
        public int? PageNumber { get; set; }

        /// <summary>
        /// Number of files to import per page.
        /// </summary>
        [JsonProperty("files_per_page")]
        public int? FilesPerPage { get; set; }

        /// <summary>
        /// Requested rendition quality. One of <see cref="Constants.VimeoRenditions"/>.
        /// </summary>
        [JsonProperty("rendition")]
        public string Rendition { get; set; }

        /// <summary>
        /// Initializes <c>/vimeo/import</c> Robot.
        /// </summary>
        public VimeoImportRobot()
        {
            Robot = "/vimeo/import";
        }
    }
}
