using System.Collections.Generic;

namespace Transloadit.Models.Robots.MediaCataloging
{
    public class FilePreviewRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Format { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string ResizeStrategy { get; set; }
        public string Background { get; set; }
        public PreviewStrategy Strategy { get; set; }
        public string WaveformCenterColor { get; set; }
        public string WaveformOuterColor { get; set; }
        public string WaveformHeight { get; set; }
        public string WaveformWidth { get; set; }
        public string IconStyle { get; set; }
        public string IconTextColor { get; set; }
        public string IconTextFont { get; set; }
        public string IconTextContent { get; set; }

        public bool? Optimize { get; set; }
        public string OptimizePriority { get; set; }
        public bool? OptimizeProgressive { get; set; }

        public string ClipFormat { get; set; }
        public double? ClipOffset { get; set; }
        public double? ClipDuration { get; set; }
        public int? ClipFramerate { get; set; }
        public bool? ClipLoop { get; set; }

        public FilePreviewRobot()
        {
            Robot = "/file/preview";
        }
    }

    public class PreviewStrategy
    {
        public List<string> Audio { get; set; }
        public List<string> Video { get; set; }
        public List<string> Document { get; set; }
        public List<string> Image { get; set; }
        public List<string> Webpage { get; set; }
        public List<string> Archive { get; set; }
        public List<string> Unknown { get; set; }
    }
}
