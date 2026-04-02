using System.Collections.Generic;
using Newtonsoft.Json;

namespace Transloadit.Models.Robots.Documents
{
    /// <summary>
    /// Represents <c>/document/optimize</c> Robot.
    /// </summary>
    public class DocumentOptimizeRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [JsonProperty("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Optional expensive metadata extraction settings.
        /// </summary>
        [JsonProperty("output_meta")]
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }

        /// <summary>
        /// Quality preset. One of <see cref="Constants.DocumentOptimizePresets"/>.
        /// </summary>
        [JsonProperty("preset")]
        public string Preset { get; set; }

        /// <summary>
        /// Target image DPI.
        /// </summary>
        [JsonProperty("image_dpi")]
        public AnyOf<int, string> ImageDpi { get; set; }

        /// <summary>
        /// Compresses embedded fonts.
        /// </summary>
        [JsonProperty("compress_fonts")]
        public bool? CompressFonts { get; set; }

        /// <summary>
        /// Subsets embedded fonts to used glyphs.
        /// </summary>
        [JsonProperty("subset_fonts")]
        public bool? SubsetFonts { get; set; }

        /// <summary>
        /// Removes document metadata.
        /// </summary>
        [JsonProperty("remove_metadata")]
        public bool? RemoveMetadata { get; set; }

        /// <summary>
        /// Enables linearized PDF output.
        /// </summary>
        [JsonProperty("linearize")]
        public bool? Linearize { get; set; }

        /// <summary>
        /// PDF compatibility level.
        /// </summary>
        [JsonProperty("compatibility")]
        public string Compatibility { get; set; }

        /// <summary>
        /// Initializes <c>/document/optimize</c> Robot.
        /// </summary>
        public DocumentOptimizeRobot()
        {
            Robot = "/document/optimize";
        }
    }
}
