namespace Transloadit.Models.Robots
{
    /// <summary>
    /// Represents <c>/upload/handle</c> Robot.
    /// </summary>
    public class UploadHandleRobot : RobotBase
    {
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }

        /// <summary>
        /// Initializes <c>/upload/handle</c> Robot.
        /// </summary>
        public UploadHandleRobot()
        {
            Robot = "/upload/handle";
        }
    }
}
