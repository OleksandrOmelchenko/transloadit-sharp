using System.Collections.Generic;
using Newtonsoft.Json;

namespace Transloadit.Models.Robots.ImageManipulation
{
    /// <summary>
    /// Represents <c>/image/resize</c> Robot.
    /// </summary>
    public class ResizeImageRobot : RobotBase
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
        /// The output format for the modified image. Some of the most important available formats are "jpg", "png", "gif", and "tiff". For 
        /// a complete lists of all formats that we can write to please check 
        /// <a href="https://transloadit.com/docs/transcoding/image-manipulation/image-resize/">supported image formats list</a>. 
        /// If <c>null</c> (default), then the input image's format will be used as the output format.
        /// <para>Default: <c>null</c>.</para>
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Width of the new image, in pixels. If not specified, will default to the width of the input image. Value 1-5000.
        /// <para>Default: auto.</para>
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Height of the new image, in pixels. If not specified, will default to the height of the input image. Value 1-5000.
        /// <para>Default: auto.</para>
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Image resize strategy. One of <see cref="Constants.ResizeStrategy"/>: <c>fit</c>, <c>fillcrop</c>, <c>min_fit</c>, 
        /// <c>pad</c>, <c>stretch</c> and <c>crop</c>.
        /// <para>Default: <c>pad</c>.</para>
        /// </summary>
        public string ResizeStrategy { get; set; }

        /// <summary>
        /// If this is set to false, smaller images will not be stretched to the desired width and height.
        /// </summary>
        public bool? Zoom { get; set; }

        /// <summary>
        /// Specify an object containing coordinates for the top left and bottom right corners of the rectangle to be cropped from the original 
        /// video(s). Values can be integers for absolute pixel values or strings for percentage based values. For example: 
        /// <code>
        /// 
        /// {
        ///   "x1": 80,
        ///   "y1": 100,
        ///   "x2": "60%",
        ///   "y2": "80%"
        /// }
        /// </code>
        /// This will crop the area from (80, 100) to (600, 800) from a 1000×1000 pixels video, which is a square whose width is 520px and height 
        /// is 700px. If crop is set, the width and height parameters are ignored, and the resize_strategy is set to crop automatically.
        /// <para>You can also use a JSON string of such an object with coordinates in similar fashion: 
        /// <c>{ \"x1\": int, \"y1\": int, \"x2\": int, \"y2\": int }</c></para>
        /// <para>Default: <c>null</c>.</para>
        /// </summary>
        public AnyOf<string, Crop> Crop { get; set; }

        /// <summary>
        /// The direction from which the image is to be cropped, when "resize_strategy" is set to "crop", but no crop coordinates are defined.
        /// <para>Default: <c>center</c>.</para>
        /// </summary>
        public string Gravity { get; set; }

        /// <summary>
        /// Strips all metadata from the image. This is useful to keep thumbnails as small as possible.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? Strip { get; set; }

        /// <summary>
        /// Gives control of the alpha/matte channel of an image. Valid options are "Activate", "Background", "Copy", "Deactivate", "Extract", "Off", "On", "Opaque", "Remove", "Set", "Shape", "Transparent".
        /// </summary>
        public string Alpha { get; set; }

        /// <summary>
        /// Gives control of the alpha/matte channel of an image before applying the clipping path via clip: true. Valid options are "Activate", "Background", "Copy", "Deactivate", "Extract", "Off", "On", "Opaque", "Remove", "Set", "Shape", "Transparent".
        /// </summary>
        public string PreclipAlpha { get; set; }

        /// <summary>
        /// Flattens all layers onto the specified background to achieve better results from transparent formats to non-transparent formats, as explained 
        /// in the <a href="https://www.imagemagick.org/script/command-line-options.php?#layers">ImageMagick documentation</a>. To preserve animations, 
        /// GIF files are not flattened when this is set to <c>true</c>. To flatten GIF animations, use the <c>frame</c> parameter.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        public bool? Flatten { get; set; }

        /// <summary>
        /// Prevents gamma errors common in many image scaling algorithms.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? CorrectGamma { get; set; }

        /// <summary>
        /// Controls the image compression for JPG and PNG images. Value 1-100.
        /// <para>Default: auto.</para>
        /// </summary>
        public int? Quality { get; set; }

        /// <summary>
        /// Controls the image compression for PNG images. Setting to <c>true</c> results in smaller file size, while increasing processing time. 
        /// It is encouraged to keep this option disabled.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? AdaptiveFilering { get; set; }

        /// <summary>
        /// Either the hexadecimal code or <a href="https://www.imagemagick.org/script/color.php#color_names">name</a> of the color used to fill 
        /// the background (only used for the <c>pad</c> resize strategy).
        /// <para>Default: <c>#FFFFFF</c>.</para>
        /// </summary>
        public string Background { get; set; }

        /// <summary>
        /// Use this parameter when dealing with animated GIF files to specify which frame of the GIF is used for the operation. Specify <c>1</c>
        /// to use the first frame, <c>2</c> to use the second, and so on. <c>null</c> means all frames.
        /// <para>Default: <c>null</c>.</para>
        /// </summary>
        public int? Frame { get; set; }

        /// <summary>
        /// Sets the image colorspace. For details about the available values, see the 
        /// <a href="https://www.imagemagick.org/script/command-line-options.php#colorspace">ImageMagick documentation</a>. ImageMagick 
        /// might try to find the most efficient colorspace based on the color of an image, and default to e.g. "Gray". 
        /// To force colors, you might have to use this parameter in combination with <c>type: "TrueColor"</c>.
        /// </summary>
        public string Colorspace { get; set; }

        /// <summary>
        /// Sets the image color type. For details about the available values, see the 
        /// <a href="https://www.imagemagick.org/script/command-line-options.php#colorspace">ImageMagick documentation</a>. If you're using 
        /// colorspace, ImageMagick might try to find the most efficient based on the color of an image, and default to e.g. "Gray". 
        /// To force colors, you could e.g. set this parameter to "TrueColor".
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Applies a sepia tone effect in percent. Value 0-99.
        /// </summary>
        public int? Sepia { get; set; }

        /// <summary>
        /// Determines whether the image should be rotated. Use integers to specify the rotation for each quarter revolution (90, 180, 270, 360). 
        /// Use the value <c>true</c> to auto-rotate images that are rotated incorrectly or depend on EXIF rotation settings. Otherwise, 
        /// use <c>false</c> to disable auto-fixing altogether.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        public AnyOf<bool, int> Rotation { get; set; }

        /// <summary>
        /// Specifies pixel compression for when the image is written. Valid values are "None", "BZip", "Fax", "Group4", "JPEG", "JPEG2000", "Lossless", "LZW", "RLE", and "Zip". Compression is disabled by default.
        /// </summary>
        public string Compress { get; set; }

        /// <summary>
        /// Specifies gaussian blur, using a value with the form <c>{radius}x{sigma}</c>. The radius value specifies the size of area the operator
        /// should look at when spreading pixels, and should typically be either <c>"0"</c> or at least two times the sigma value. 
        /// The sigma value is an approximation of how many pixels the image is "spread"; think of it as the size of the brush used to blur the image. 
        /// This number is a floating point value, enabling small values like <c>"0.5"</c> to be used.
        /// </summary>
        public string Blur { get; set; }

        /// <summary>
        /// Specifies an array of ellipse objects that should be blurred on the image. Each object has the following keys: <c>x</c>, <c>y</c>, 
        /// <c>width</c>, <c>height</c>. If <c>blur_regions</c> has a value, then the <c>blur</c> parameter is used as the strength of the blur 
        /// for each region.
        /// </summary>
        public List<BlurRegion> BlurRegions { get; set; }

        /// <summary>
        /// Increases or decreases the brightness of the image by using a multiplier. For example <c>1.5</c> would increase the brightness by 50%, 
        /// and <c>0.75</c> would decrease the brightness by 25%.
        /// <para>Default: <c>1</c>.</para>
        /// </summary>
        public int? Brightness { get; set; }

        /// <summary>
        /// Increases or decreases the saturation of the image by using a multiplier. For example <c>1.5</c> would increase the saturation by 50%, 
        /// and <c>0.75</c> would decrease the saturation by 25%.
        /// <para>Default: <c>1</c>.</para>
        /// </summary>
        public int? Saturation { get; set; }

        /// <summary>
        /// Changes the hue by rotating the color of the image. The value <c>100</c> would produce no change whereas <c>0</c> and <c>200</c> will 
        /// negate the colors in the image.
        /// <para>Default: <c>100</c>.</para>
        /// </summary>
        public int? Hue { get; set; }

        /// <summary>
        /// Interlaces the image if set to <c>true</c>, which makes the image load progressively in browsers. Instead of rendering the image
        /// from top to bottom, the browser will first show a low-res blurry version of the images which is then quickly replaced with the 
        /// actual image as the data arrives. This greatly increases the user experience, but comes at a cost of a file size increase by around 10%.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? Progressive { get; set; }

        /// <summary>
        /// Make this color transparent within the image. Formats which support this parameter include "GIF", "PNG", "BMP", "TIFF", "WebP", and "JP2".
        /// </summary>
        public string Transparent { get; set; }

        /// <summary>
        /// This determines if additional whitespace around the image should first be trimmed away. If you set this to <c>true</c> this parameter 
        /// removes any edges that are exactly the same color as the corner pixels.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? TrimWhitespace { get; set; }

        /// <summary>
        /// Apply the clipping path to other operations in the resize job, if one is present. If set to <c>true</c>, it will automatically take 
        /// the first clipping path. If set to a String it finds a clipping path by that name.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public AnyOf<bool, string> Clip { get; set; }

        /// <summary>
        /// Replace each pixel with its complementary color, effectively negating the image. Especially useful when testing clipping.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? Negate { get; set; }

        /// <summary>
        /// While in-memory quality and file format depth specifies the color resolution, the density of an image is the spatial (space) resolution 
        /// of the image. That is the density (in pixels per inch) of an image and defines how far apart (or how big) the individual pixels are. 
        /// It defines the size of the image in real world terms when displayed on devices or printed.
        /// <para>You can set this value to a specific <c>width</c> or in the format <c>{width}x{height}</c>.</para>
        /// <para>If your converted image is unsharp, please try increasing density.</para>
        /// <para>Default: <c>null</c>.</para>
        /// </summary>
        public int? Density { get; set; }

        /// <summary>
        /// ImageMagic stack version. One of <see cref="Constants.ImageMagickStack"/>: <c>v2.0.10</c> or <c>v3.0.1</c>.
        /// <para>Default: <c>v2.0.10</c>.</para>
        /// </summary>
        public string ImagemagickStack { get; set; }

        /// <summary>
        /// An array of objects each containing text rules. The following text parameters are intended to be used as properties 
        /// for your array of text overlays.
        /// </summary>
        public List<TextData> Text { get; set; }

        /// <summary>
        /// A URL indicating a PNG image to be overlaid above this image. Please note that you can also supply the watermark via another 
        /// Assembly Step. With watermarking you can add an image onto another image. This is usually used for logos.
        /// </summary>
        public string WatermarkUrl { get; set; }

        /// <summary>
        /// The position at which the watermark is placed. The available options are "center", "top", "bottom", "left", and "right". You can also combine options, such as "bottom-right".
        /// <para>An array of possible values can also be specified, in which case one value will be selected at random, such as <c>[ "center", "left", "bottom-left", "bottom-right" ]</c>.</para>
        /// <para>This setting puts the watermark in the specified corner. To use a specific pixel offset for the watermark, you will need to 
        /// add the padding to the image itself.</para>
        /// <para>Default: <c>center</c>.</para>
        /// </summary>
        public AnyOf<string, List<string>> WatermarkPosition { get; set; }

        /// <summary>
        /// The x-offset in number of pixels at which the watermark will be placed in relation to the position it has due to <c>watermark_position</c>.
        /// <para>Values can be both positive and negative and yield different results depending on the <c>watermark_position</c> parameter. 
        /// Positive values move the watermark closer to the image's center point, whereas negative values move the watermark 
        /// further away from the image's center point.</para>
        /// <para>Default: <c>0</c>.</para>
        /// </summary>
        public int? WatermarkXOffset { get; set; }

        /// <summary>
        /// The y-offset in number of pixels at which the watermark will be placed in relation to the position it has due to <c>watermark_position</c>.
        /// <para>Values can be both positive and negative and yield different results depending on the <c>watermark_position</c> parameter. 
        /// Positive values move the watermark closer to the image's center point, whereas negative values move the watermark 
        /// further away from the image's center point.</para>
        /// <para>Default: <c>0</c>.</para>
        /// </summary>
        public int? WatermarkYOffset { get; set; }

        /// <summary>
        /// The size of the watermark, as a percentage.
        /// <para>For example, a value of <c>50%</c> means that size of the watermark will be 50% of the size of image on which it is placed. 
        /// The exact sizing depends on <c>watermark_resize_strategy</c>, too.</para>
        /// </summary>
        public string WatermarkSize { get; set; }

        /// <summary>
        /// Available values are <c>fit</c>, <c>min_fit</c>, <c>stretch</c> and <c>area</c>.
        /// <para>Default: <c>fit</c>.</para>
        /// </summary>
        public string WatermarkResizeStrategy { get; set; }

        /// <summary>
        /// Initializes <c>/image/resize</c> Robot.
        /// </summary>
        public ResizeImageRobot()
        {
            Robot = "/image/resize";
        }
    }

    /// <summary>
    /// Represents text properties configuration.
    /// </summary>
    public class TextData
    {
        /// <summary>
        /// Text content.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The font family to use. Also includes boldness and style of the font. One of <see cref="Constants.Fonts"/>.
        /// <para>Default: <c>Arial</c>.</para>
        /// </summary>
        public string Font { get; set; }

        /// <summary>
        /// The text size in pixels.
        /// <para>Default: <c>12</c>.</para>
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// The rotation angle in degrees.
        /// <para>Default: <c>0</c>.</para>
        /// </summary>
        public int? Rotate { get; set; }

        /// <summary>
        /// The text color. All hex colors in the form "#xxxxxx" are supported, where each x can be 0-9 or a-f. "transparent" is also supported if you want a transparent text color. In that case use "stroke" instead, otherwise your text will not be visible.
        /// <para>Default: <c>#000000</c>.</para>
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The text color. All hex colors in the form "#xxxxxx" are supported, where each x is can be 0-9 or a-f. "transparent" is also supported.
        /// <para>Default: <c>transparent</c>.</para>
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// The stroke's width in pixels.
        /// <para>Default: <c>0</c>.</para>
        /// </summary>
        public int? StrokeWidth { get; set; }

        /// <summary>
        /// The stroke's color. All hex colors in the form "#xxxxxx" are supported, where each x is can be 0-9 or a-f. "transparent" is also supported.
        /// <para>Default: <c>transparent</c>.</para>
        /// </summary>
        public string StrokeColor { get; set; }

        /// <summary>
        /// The horizontal text alignment. Can be "left", "center" and "right".
        /// <para>Default: <c>center</c>.</para>
        /// </summary>
        public string Align { get; set; }

        /// <summary>
        /// The vertical text alignment. Can be "top", "center" and "bottom".
        /// <para>Default: <c>center</c>.</para>
        /// </summary>
        public string Valign { get; set; }

        /// <summary>
        /// The horizontal offset for the text in pixels that is added (positive integer) or removed (negative integer) from the horizontal alignment.
        /// <para>Default: <c>0</c>.</para>
        /// </summary>
        public int? XOffset { get; set; }

        /// <summary>
        /// The vertical offset for the text in pixels that is added (positive integer) or removed (negative integer) from the vertical alignment.
        /// <para>Default: <c>0</c>.</para>
        /// </summary>
        public int? YOffset { get; set; }
    }

    /// <summary>
    /// Represents crop settings.
    /// </summary>
    public class Crop
    {
        /// <summary>
        /// x1 coordinate.
        /// </summary>
        [JsonProperty("x1")]
        public int X1 { get; set; }

        /// <summary>
        /// y1 coordinate.
        /// </summary>
        [JsonProperty("y1")]
        public int Y1 { get; set; }

        /// <summary>
        /// x2 coordinate.
        /// </summary>
        [JsonProperty("x2")]
        public string X2 { get; set; }

        /// <summary>
        /// y2 coordinate.
        /// </summary>
        [JsonProperty("y2")]
        public string Y2 { get; set; }
    }

    /// <summary>
    /// Represents blur ellipse region settings.
    /// </summary>
    public class BlurRegion
    {
        /// <summary>
        /// Region x.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Region y.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Region width.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Region height.
        /// </summary>
        public int Height { get; set; }
    }
}
