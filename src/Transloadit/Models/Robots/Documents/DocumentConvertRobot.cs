using System.Collections.Generic;

namespace Transloadit.Models.Robots.Documents
{
    /// <summary>
    /// Represents <c>/document/convert</c> Robot.
    /// </summary>
    public class DocumentConvertRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
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

        /// <summary>
        /// Initializes <c>/document/convert</c> Robot.
        /// </summary>
        public DocumentConvertRobot()
        {
            Robot = "/document/convert";
        }
    }
}
