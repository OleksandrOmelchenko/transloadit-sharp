using Newtonsoft.Json;

namespace Transloadit.Models.Robots

{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/upload-handle/">/upload/handle</a> Robot.
    /// </summary>
    public class UploadHandleRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/upload-handle/">/upload/handle</a> Robot.
        /// </summary>
        public UploadHandleRobot()
        {
            Robot = "/upload/handle";
        }
    }
}

