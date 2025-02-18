using System.Collections.Generic;

namespace Transloadit.Models.Robots.Documents
{
    public class DocumentThumbnailsRobot : RobotBase
    {
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
        public string ImagemagickStack { get; set; }

        public DocumentThumbnailsRobot()
        {
            Robot = "/document/thumbs";
        }
    }
}
