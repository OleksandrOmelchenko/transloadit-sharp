using System.Collections.Generic;

namespace Transloadit.Models.Robots.Documents
{
    /// <summary>
    /// Represents <c>/document/thumbs</c> Robot.
    /// </summary>
    public class DocumentThumbnailsRobot : RobotBase
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
        /// The PDF page that you want to convert to an image. By default the value is <c>null</c> which means that all pages will be converted into images.
        /// </summary>
        public int? Page { get; set; }
        public string Format { get; set; }

        /// <summary>
        /// If your output format is <c>gif</c> then this parameter sets the number of 100th seconds to pass before the next frame is shown 
        /// in the animation. Set this to <c>100</c> for example to allow 1 second to pass between the frames of the animated gif. 
        /// If your output format is not <c>gif</c>, then this parameter does not have any effect.
        /// </summary>
        public int? Delay { get; set; }

        /// <summary>
        /// Width of the new image, in pixels. If not specified, will default to the width of the input image
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Height of the new image, in pixels. If not specified, will default to the height of the input image
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Image resize strategy. One of <see cref="Constants.ResizeStrategy"/>: <c>fit</c>, <c>fillcrop</c>, <c>min_fit</c>, 
        /// <c>pad</c>, <c>stretch</c> and <c>crop</c>.
        /// <para>Default: <c>pad</c>.</para>
        /// </summary>
        public string ResizeStrategy { get; set; }

        /// <summary>
        /// Either the hexadecimal code or <a href="https://www.imagemagick.org/script/color.php#color_names">name</a> of the color used to fill 
        /// the background (only used for the <c>pad</c> resize strategy).
        /// <para>Default: <c>#FFFFFF</c>.</para>
        /// </summary>
        public string Background { get; set; }

        /// <summary>
        /// Change how the alpha channel of the resulting image should work. Valid values are <c>Set</c> to enable transparency 
        /// and <c>Remove</c> to remove transparency. For a list of all valid values please check the ImageMagick documentation 
        /// <a href="http://www.imagemagick.org/script/command-line-options.php?#alpha">here</a>.
        /// </summary>
        public string Alpha { get; set; }

        /// <summary>
        /// While in-memory quality and file format depth specifies the color resolution, the density of an image is the spatial (space) 
        /// resolution of the image. That is the density (in pixels per inch) of an image and defines how far apart (or how big) 
        /// the individual pixels are. It defines the size of the image in real world terms when displayed on devices or printed.
        /// You can set this value to a specific <c>width</c> or in the format <c>widthxheight</c>.
        /// </summary>
        public string Density { get; set; }

        /// <summary>
        /// Controls whether or not antialiasing is used to remove jagged edges from text or images in a document.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? Antialiasing { get; set; }

        /// <summary>
        /// Sets the image colorspace. For details about the available values, see the 
        /// <a href="https://www.imagemagick.org/script/command-line-options.php#colorspace">ImageMagick documentation</a>.
        /// </summary>
        public string Colorspace { get; set; }

        /// <summary>
        /// This determines if additional whitespace around the PDF should first be trimmed away before it is converted to an image. 
        /// If you set this to <c>true</c> only the real PDF page contents will be shown in the image. If you need to reflect the PDF's dimensions 
        /// in your image, it is generally a good idea to set this to <c>false</c>.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        public bool? TrimWhitespace { get; set; }

        /// <summary>
        /// Some PDF documents lie about their dimensions. For instance they'll say they are landscape, but when opened in decent Desktop readers, 
        /// it's really in portrait mode. This can happen if the document has a cropbox defined. When this option is enabled (by default), 
        /// the cropbox is leading in determining the dimensions of the resulting thumbnails.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        public bool? PdfUseCropbox { get; set; }

        /// <summary>
        /// ImageMagic stack version. One of <see cref="Constants.ImageMagickStack"/>: <c>v2.0.10</c> or <c>v3.0.1</c>.
        /// <para>Default: <c>v2.0.10</c>.</para>
        /// </summary>
        public string ImagemagickStack { get; set; }

        /// <summary>
        /// Initializes <c>/document/thumbs</c> Robot.
        /// </summary>
        public DocumentThumbnailsRobot()
        {
            Robot = "/document/thumbs";
        }
    }
}
