using Newtonsoft.Json;

namespace Transloadit.Models.Robots

{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/upload-handle/">/upload/handle</a> Robot.
    /// </summary>
    public class UploadHandleRobot : RobotBase
    {
        /// <summary>
        /// Allows to specify a set of metadata that is more expensive on CPU power to calculate, 
        /// and thus is disabled by default to keep your Assemblies processing fast.
        /// This can be set to <c>false</c> to skip metadata extraction and speed up transcoding.
        /// <para>Default: <c>{}</c>.</para>
        /// </summary>
        [JsonProperty("output_meta")]
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/upload-handle/">/upload/handle</a> Robot.
        /// </summary>
        public UploadHandleRobot()
        {
            Robot = "/upload/handle";
        }
    }
}

