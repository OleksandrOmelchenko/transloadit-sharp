namespace Transloadit.Models.Robots
{
    /// <summary>
    /// Represents <c>/upload/handle</c> Robot.
    /// </summary>
    public class UploadHandleRobot : RobotBase
    {
        /// <summary>
        /// Allows to specify a set of metadata that is more expensive on CPU power to calculate, 
        /// and thus is disabled by default to keep your Assemblies processing fast.
        /// This can be set to <c>false</c> to skip metadata extraction and speed up transcoding.
        /// <para>Default: <c>{}</c>.</para>
        /// </summary>
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
