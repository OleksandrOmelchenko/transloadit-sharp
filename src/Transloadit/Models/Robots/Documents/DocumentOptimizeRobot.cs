using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.Documents;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/document-optimize/">/document/optimize</a> Robot.
/// </summary>
public class DocumentOptimizeRobot : ProcessingRobotBase
{
    /// <summary>
    /// Specifies which Step(s) to use as input.
    /// </summary>
    [TransloaditJsonName("use")]
    public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

    /// <summary>
    /// Quality preset. One of <see cref="Constants.DocumentOptimizePresets"/>.
    /// </summary>
    [TransloaditJsonName("preset")]
    public string Preset { get; set; }

    /// <summary>
    /// Target image DPI.
    /// </summary>
    [TransloaditJsonName("image_dpi")]
    public AnyOf<int, string> ImageDpi { get; set; }

    /// <summary>
    /// Compresses embedded fonts.
    /// </summary>
    [TransloaditJsonName("compress_fonts")]
    public bool? CompressFonts { get; set; }

    /// <summary>
    /// Subsets embedded fonts to used glyphs.
    /// </summary>
    [TransloaditJsonName("subset_fonts")]
    public bool? SubsetFonts { get; set; }

    /// <summary>
    /// Removes document metadata.
    /// </summary>
    [TransloaditJsonName("remove_metadata")]
    public bool? RemoveMetadata { get; set; }

    /// <summary>
    /// Enables linearized PDF output.
    /// </summary>
    [TransloaditJsonName("linearize")]
    public bool? Linearize { get; set; }

    /// <summary>
    /// PDF compatibility level.
    /// </summary>
    [TransloaditJsonName("compatibility")]
    public string Compatibility { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/document-optimize/">/document/optimize</a> Robot.
    /// </summary>
    public DocumentOptimizeRobot()
    {
        Robot = "/document/optimize";
    }
}
