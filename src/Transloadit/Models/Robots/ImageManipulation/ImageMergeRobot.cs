using Transloadit.Serialization.Attributes;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.ImageManipulation
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/image-merge/">/image/merge</a> Robot.
    /// </summary>
    public class ImageMergeRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [TransloaditJsonName("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// The output format for the modified image. The currently available formats are either <c>jpg</c> or <c>png</c>.
        /// <para>Default: <c>png</c>.</para>
        /// </summary>
        [TransloaditJsonName("format")]
        public string Format { get; set; }

        /// <summary>
        /// Specifies the direction which the images are displayed. Valid directions include <c>vertical</c> and <c>horizontal</c>.
        /// <para>Default: <c>horizontal</c>.</para>
        /// </summary>
        [TransloaditJsonName("direction")]
        public string Direction { get; set; }

        /// <summary>
        /// An integer value which defines the gap between images on the spritesheet. Value 1-10. A value of <c>10</c> would cause the 
        /// images to have the largest gap between them, while a value of <c>1</c> would place the images side-by-side.
        /// <para>Default: <c>0</c>.</para>
        /// </summary>
        [TransloaditJsonName("border")]
        public int? Border { get; set; }

        /// <summary>
        /// Either the hexadecimal code or <a href="https://www.imagemagick.org/script/color.php#color_names">name</a> of the color used to 
        /// fill the background (only shown with a border > 1). By default, the background of transparent images is changed to white.
        /// <para>Default: <c>#FFFFFF</c>.</para>
        /// </summary>
        [TransloaditJsonName("background")]
        public string Background { get; set; }

        /// <summary>
        /// Controls the image compression for PNG images. Setting to true results in smaller file size, while increasing processing time. It is encouraged to keep this option disabled.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        [TransloaditJsonName("adaptive_filtering")]
        public bool? AdaptiveFiltering { get; set; }

        /// <summary>
        /// Controls the image compression for JPG and PNG images. Value 1-100.
        /// <para>Default: <c>92</c>.</para>
        /// </summary>
        [TransloaditJsonName("quality")]
        public int? Quality { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/image-merge/">/image/merge</a> Robot.
        /// </summary>
        public ImageMergeRobot()
        {
            Robot = "/image/merge";
        }
    }
}
