using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.ImageManipulation
{
    /// <summary>
    /// Represents <c>/image/bgremove</c> Robot.
    /// </summary>
    public class ImageBackgroundRemove : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [JsonProperty("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// The output format for the modified image. Currently, only <c>png</c> is supported. 
        /// To change the image format, you can use <see cref="ImageResizeRobot"/>.
        /// <para>Default: <c>png</c>.</para>
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// Initializes <c>/image/bgremove</c> Robot.
        /// </summary>
        public ImageBackgroundRemove()
        {
            Robot = "/image/bgremove";
        }
    }
}
