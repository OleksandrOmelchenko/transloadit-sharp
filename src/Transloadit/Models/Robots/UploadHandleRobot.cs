namespace Transloadit.Models.Robots
{
    public class UploadHandleRobot : RobotBase
    {
        public AnyOf<bool, UploadOutputMeta> OutputMeta { get; set; }

        public UploadHandleRobot()
        {
            Robot = "/upload/handle";
        }
    }

    public class UploadOutputMeta
    {
        public bool? HasTransparency { get; set; }
        public bool? DominantColors { get; set; }
        public bool? Colorspace { get; set; }
        public bool? MeanVolume { get; set; }
    }
}
