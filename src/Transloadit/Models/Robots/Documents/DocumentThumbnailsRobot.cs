using System.Collections.Generic;

namespace Transloadit.Models.Robots.Documents
{
    /// <summary>
    /// Represents <c>/document/thumbs</c> Robot.
    /// </summary>
    public class DocumentThumbnailsRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }
        public int? Page { get; set; }
        public string Format { get; set; }
        public int? Delay { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string ResizeStrategy { get; set; }
        public string Background { get; set; }
        public string Alpha { get; set; }
        public string Density { get; set; }
        public bool? Antialiasing { get; set; }
        public string Colorspace { get; set; }
        public bool? TrimWhitespace { get; set; }
        public bool? PdfUseCropbox { get; set; }

        /// <summary>
        /// ImageMagic stack version. One of <see cref="Constants.ImageMagickStack"/>: <c>v2.0.10</c> or <c>v3.0.1</c>.
        /// <para>Default: <c>v2.0.10</c>.</para>
        /// </summary>
        public string ImagemagickStack { get; set; }

        /// <summary>
        /// Initializes <c>/document/thumbs</c> Robot.
        /// </summary>
        public DocumentThumbnailsRobot()
        {
            Robot = "/document/thumbs";
        }
    }
}
