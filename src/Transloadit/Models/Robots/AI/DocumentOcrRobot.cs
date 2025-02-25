using System.Collections.Generic;

namespace Transloadit.Models.Robots.AI
{
    /// <summary>
    /// Represents <c>/document/ocr</c> Robot.
    /// </summary>
    public class DocumentOcrRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Provider { get; set; }
        public string Granularity { get; set; }
        public string Format { get; set; }

        /// <summary>
        /// Initializes <c>/document/ocr</c> Robot.
        /// </summary>
        public DocumentOcrRobot()
        {
            Robot = "/document/ocr";
        }
    }
}
