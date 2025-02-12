using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots.Documents
{
    public class DocumentConvertRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Format { get; set; }
        public string MarkdownFormat { get; set; }
        public string MarkdownTheme { get; set; }
        public string PdfMargin { get; set; }
        public string PdfPrintBackground { get; set; }
        public string PdfFormat { get; set; }
        public bool? PdfDisplayHeaderFooter { get; set; }
        public string PdfHeaderTemplate { get; set; }
        public string PdfFooterTemplate { get; set; }

        public DocumentConvertRobot()
        {
            Robot = "/document/convert";
        }
    }
}
