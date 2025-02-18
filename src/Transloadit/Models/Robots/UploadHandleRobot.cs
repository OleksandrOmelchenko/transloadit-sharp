namespace Transloadit.Models.Robots
{
    public class UploadHandleRobot : RobotBase
    {
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }

        public UploadHandleRobot()
        {
            Robot = "/upload/handle";
        }
    }
}
