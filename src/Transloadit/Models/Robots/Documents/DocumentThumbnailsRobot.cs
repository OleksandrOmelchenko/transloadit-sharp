using Transloadit.Serialization.Attributes;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.Documents
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/document-thumbs/">/document/thumbs</a> Robot.
    /// </summary>
    public class DocumentThumbnailsRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [TransloaditJsonName("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// The PDF page that you want to convert to an image. By default the value is <c>null</c> which means that all pages will be converted into images.
        /// </summary>
        [TransloaditJsonName("page")]
        public int? Page { get; set; }

        /// <summary>
        /// The format of the extracted image(s). If you specify the value <c>gif</c>, then an animated gif cycling through all pages is created.
        /// <para>Default: <c>png</c>.</para>
        /// </summary>
        [TransloaditJsonName("format")]
        public string Format { get; set; }

        /// <summary>
        /// If your output format is <c>gif</c> then this parameter sets the number of 100th seconds to pass before the next frame is shown 
        /// in the animation. Set this to <c>100</c> for example to allow 1 second to pass between the frames of the animated gif. 
        /// If your output format is not <c>gif</c>, then this parameter does not have any effect.
        /// </summary>
        [TransloaditJsonName("delay")]
        public int? Delay { get; set; }

        /// <summary>
        /// Width of the new image, in pixels. If not specified, will default to the width of the input image
        /// </summary>
        [TransloaditJsonName("width")]
        public int? Width { get; set; }

        /// <summary>
        /// Height of the new image, in pixels. If not specified, will default to the height of the input image
        /// </summary>
        [TransloaditJsonName("height")]
        public int? Height { get; set; }

        /// <summary>
        /// Image resize strategy. One of <see cref="Constants.ResizeStrategy"/>: <c>fit</c>, <c>fillcrop</c>, <c>min_fit</c>, 
        /// <c>pad</c>, <c>stretch</c> and <c>crop</c>.
        /// <para>Default: <c>pad</c>.</para>
        /// </summary>
        [TransloaditJsonName("resize_strategy")]
        public string ResizeStrategy { get; set; }

        /// <summary>
        /// Either the hexadecimal code or <a href="https://www.imagemagick.org/script/color.php#color_names">name</a> of the color used to fill 
        /// the background (only used for the <c>pad</c> resize strategy).
        /// <para>Default: <c>#FFFFFF</c>.</para>
        /// </summary>
        [TransloaditJsonName("background")]
        public string Background { get; set; }

        /// <summary>
        /// Change how the alpha channel of the resulting image should work. Valid values are <c>Set</c> to enable transparency 
        /// and <c>Remove</c> to remove transparency. For a list of all valid values please check the ImageMagick documentation 
        /// <a href="http://www.imagemagick.org/script/command-line-options.php?#alpha">here</a>.
        /// </summary>
        [TransloaditJsonName("alpha")]
        public string Alpha { get; set; }

        /// <summary>
        /// While in-memory quality and file format depth specifies the color resolution, the density of an image is the spatial (space) 
        /// resolution of the image. That is the density (in pixels per inch) of an image and defines how far apart (or how big) 
        /// the individual pixels are. It defines the size of the image in real world terms when displayed on devices or printed.
        /// You can set this value to a specific <c>width</c> or in the format <c>widthxheight</c>.
        /// </summary>
        [TransloaditJsonName("density")]
        public string Density { get; set; }

        /// <summary>
        /// Controls whether or not antialiasing is used to remove jagged edges from text or images in a document.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        [TransloaditJsonName("antialiasing")]
        public bool? Antialiasing { get; set; }

        /// <summary>
        /// Sets the image colorspace. For details about the available values, see the 
        /// <a href="https://www.imagemagick.org/script/command-line-options.php#colorspace">ImageMagick documentation</a>.
        /// </summary>
        [TransloaditJsonName("colorspace")]
        public string Colorspace { get; set; }

        /// <summary>
        /// This determines if additional whitespace around the PDF should first be trimmed away before it is converted to an image. 
        /// If you set this to <c>true</c> only the real PDF page contents will be shown in the image. If you need to reflect the PDF's dimensions 
        /// in your image, it is generally a good idea to set this to <c>false</c>.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        [TransloaditJsonName("trim_whitespace")]
        public bool? TrimWhitespace { get; set; }

        /// <summary>
        /// Some PDF documents lie about their dimensions. For instance they'll say they are landscape, but when opened in decent Desktop readers, 
        /// it's really in portrait mode. This can happen if the document has a cropbox defined. When this option is enabled (by default), 
        /// the cropbox is leading in determining the dimensions of the resulting thumbnails.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        [TransloaditJsonName("pdf_use_cropbox")]
        public bool? PdfUseCropbox { get; set; }

        /// <summary>
        /// ImageMagick stack version. One of <see cref="Constants.ImageMagickStack"/>: <c>v2.0.10</c> or <c>v3.0.1</c>.
        /// <para>Default: <c>v2.0.10</c>.</para>
        /// </summary>
        [TransloaditJsonName("imagemagick_stack")]
        public string ImageMagickStack { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/document-thumbs/">/document/thumbs</a> Robot.
        /// </summary>
        public DocumentThumbnailsRobot()
        {
            Robot = "/document/thumbs";
        }
    }
}
