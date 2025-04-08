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
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Allows to specify a set of metadata that is more expensive on CPU power to calculate, 
        /// and thus is disabled by default to keep your Assemblies processing fast.
        /// This can be set to <c>false</c> to skip metadata extraction and speed up transcoding.
        /// <para>Default: <c>{}</c>.</para>
        /// </summary>
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }

        /// <summary>
        /// The output format for the modified image. Currently, only <c>png</c> is supported. 
        /// To change the image format, you can use <see cref="ImageResizeRobot"/>.
        /// <para>Default: <c>png</c>.</para>
        /// </summary>
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
