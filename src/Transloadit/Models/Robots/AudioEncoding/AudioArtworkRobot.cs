using System.Collections.Generic;

namespace Transloadit.Models.Robots.AudioEncoding
{
    public class AudioArtworkRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Method { get; set; }
        public bool? ChangeFormatIfNecessary { get; set; }
        public string FfmpegStack { get; set; }

        public AudioArtworkRobot()
        {
            Robot = "/audio/artwork";
        }
    }
}
