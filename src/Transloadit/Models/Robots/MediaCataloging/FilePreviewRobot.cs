using System.Collections.Generic;

namespace Transloadit.Models.Robots.MediaCataloging
{
    /// <summary>
    /// Represents <c>/file/preview</c> Robot.
    /// </summary>
    public class FilePreviewRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// The output format for the generated thumbnail image. If a short video clip is generated using the clip strategy,
        /// its format is defined by <c>clip_format</c>.
        /// <para>Default: <c>png</c>.</para>
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Width of the thumbnail, in pixels. Value 1-5000.
        /// <para>Default: <c>300</c>.</para>
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Height of the thumbnail, in pixels. Value 1-5000.
        /// <para>Default: <c>200</c>.</para>
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// To achieve the desired dimensions of the preview thumbnail, the Robot might have to resize the generated image. This happens, for example, 
        /// when the dimensions of a frame extracted from a video do not match the chosen width and height parameters.
        /// One of <see cref="Constants.ResizeStrategy"/>: <c>fit</c>, <c>fillcrop</c>, <c>min_fit</c>, <c>pad</c>, <c>stretch</c> and <c>crop</c>.
        /// <para>Default: <c>pad</c>.</para>
        /// </summary>
        public string ResizeStrategy { get; set; }

        /// <summary>
        /// The hexadecimal code of the color used to fill the background (only used for the pad resize strategy). The format is #rrggbb[aa] 
        /// (red, green, blue, alpha). Use <c>#00000000</c> for a transparent padding.
        /// <para>Default: <c>#ffffffff</c>.</para>
        /// </summary>
        public string Background { get; set; }

        /// <summary>
        /// Definition of the thumbnail generation process per file category. The parameter must be an object whose keys can be one of the file 
        /// categories: <c>audio</c>, <c>video</c>, <c>image</c>, <c>document</c>, <c>archive</c>, <c>webpage</c>, and <c>unknown</c>. 
        /// </summary>
        public PreviewStrategy Strategy { get; set; }

        /// <summary>
        /// The color used in the center of the waveform's gradient. The format is #rrggbb[aa] (red, green, blue, alpha). 
        /// Only used if the <c>waveform</c> strategy for audio files is applied.
        /// <para>Default: <c>#000000ff</c>.</para>
        /// </summary>
        public string WaveformCenterColor { get; set; }

        /// <summary>
        /// The color used in the outer parts of the waveform's gradient. The format is #rrggbb[aa] (red, green, blue, alpha). 
        /// Only used if the <c>waveform</c> strategy for audio files is applied.
        /// <para>Default: <c>#000000ff</c>.</para>
        /// </summary>
        public string WaveformOuterColor { get; set; }

        /// <summary>
        /// Height of the waveform, in pixels. Only used if the waveform strategy for audio files is applied. 
        /// It can be utilized to ensure that the waveform only takes up a section of the preview thumbnail. Value 1-5000.
        /// <para>Default: <c>100</c>.</para>
        /// </summary>
        public string WaveformHeight { get; set; }

        /// <summary>
        /// Width of the waveform, in pixels. Only used if the waveform strategy for audio files is applied. 
        /// It can be utilized to ensure that the waveform only takes up a section of the preview thumbnail. Value 1-5000.
        /// <para>Default: <c>300</c>.</para>
        /// </summary>
        public string WaveformWidth { get; set; }

        /// <summary>
        /// The style of the icon generated if the icon strategy is applied. The default style, <c>with-text</c>, includes an icon showing the 
        /// file type and a text box below it, whose content can be controlled by the <c>icon_text_content</c> parameter and defaults to the 
        /// file extension (e.g. MP4, JPEG). The <c>square</c> style only includes a square variant of the icon showing the file type.
        /// <para>Default: <c>with-text</c>.</para>
        /// </summary>
        public string IconStyle { get; set; }

        /// <summary>
        /// The color of the text used in the icon. The format is #rrggbb[aa]. Only used if the <c>icon</c> strategy is applied.
        /// <para>Default: <c>#a2a2a2</c>.</para>
        /// </summary>
        public string IconTextColor { get; set; }

        /// <summary>
        /// The font family of the text used in the icon. Only used if the <c>icon</c> strategy is applied. 
        /// One of <see cref="Constants.Fonts"/>.
        /// <para>Default: <c>Roboto</c>.</para>
        /// </summary>
        public string IconTextFont { get; set; }

        /// <summary>
        /// The content of the text box in generated icons. Only used if the <c>icon_style</c> parameter is set to <c>with-text</c>. The default value, 
        /// <c>extension</c>, adds the file extension (e.g. MP4, JPEG) to the icon. The value <c>none</c> can be used to render an empty text box,
        /// which is useful if no text should not be included in the raster image, but some place should be reserved in the image for later 
        /// overlaying custom text over the image using HTML etc.
        /// <para>Default: <c>extension</c>.</para>
        /// </summary>
        public string IconTextContent { get; set; }

        /// <summary>
        /// Specifies whether the generated preview image should be optimized to reduce the image's file size while keeping their quaility. 
        /// If enabled, the images will be optimized using <c>/image/optimize</c> Robot.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        public bool? Optimize { get; set; }

        /// <summary>
        /// Specifies whether conversion speed or compression ratio is prioritized when optimizing images. Only used if <c>optimize</c> is enabled.
        /// <para>Default: <c>conversion-speed</c>.</para>
        /// </summary>
        public string OptimizePriority { get; set; }

        /// <summary>
        /// Specifies whether images should be interlaced, which makes the result image load progressively in browsers. 
        /// Only used if <c>optimize</c> is enabled. 
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? OptimizeProgressive { get; set; }

        /// <summary>
        /// The animated image format for the generated video clip. Only used if the <c>clip</c> strategy for video files is applied. 
        /// Possible formats are <c>webp</c>, <c>apng</c>, <c>avif</c> and <c>gif</c>. 
        /// <para>Default: <c>webp</c>.</para>
        /// </summary>
        public string ClipFormat { get; set; }

        /// <summary>
        /// The start position in seconds of where the clip is cut. Only used if the <c>clip</c> strategy for video files is applied. 
        /// Be aware that for larger video only the first few MBs of the file may be imported to improve speed. 
        /// Larger offsets may seek to a position outside of the imported part and thus fail to generate a clip.
        /// <para>Default: <c>1</c>.</para>
        /// </summary>
        public double? ClipOffset { get; set; }

        /// <summary>
        /// The duration in seconds of the generated video clip. Only used if the <c>clip</c> strategy for video files is applied. 
        /// Be aware that a longer clip duration also results in a larger file size, which might be undesirable for previews.
        /// <para>Default: <c>5</c>.</para>
        /// </summary>
        public double? ClipDuration { get; set; }

        /// <summary>
        /// The framerate of the generated video clip. Only used if the <c>clip</c> strategy for video files is applied. 
        /// Be aware that a higher framerate appears smoother but also results in a larger file size, 
        /// which might be undesirable for previews. Value 1-60.
        /// <para>Default: <c>5</c>.</para>
        /// </summary>
        public int? ClipFramerate { get; set; }

        /// <summary>
        /// Specifies whether the generated animated image should loop forever (<c>true</c>) or stop after playing the animation 
        /// once (<c>false</c>). Only used if the clip strategy for video files is applied.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        public bool? ClipLoop { get; set; }

        /// <summary>
        /// Initializes <c>/file/preview</c> Robot.
        /// </summary>
        public FilePreviewRobot()
        {
            Robot = "/file/preview";
        }
    }

    /// <summary>
    /// Represents preview strategy for a file category.
    /// </summary>
    public class PreviewStrategy
    {
        /// <summary>
        /// Available strategies are:
        /// <list type="bullet">
        /// <item><c>artwork</c>: extract artwork embedded in the audio file, if available, using the <c>/audio/artwork</c> Robot.</item>
        /// <item><c>waveform</c>: generate a waveform visualizing the audio intensity over time, using the <c>/audio/waveform</c> Robot.</item>
        /// <item><c>icon</c>: generates a generic thumbnail featuring a category-specific icon and optionally the file's extension, 
        /// using the <c>/image/resize</c> Robot.</item>
        /// </list>
        /// Default: <c>["artwork", "waveform", "icon"]</c>.
        /// </summary>
        public List<string> Audio { get; set; }

        /// <summary>
        /// Available strategies are:
        /// <list type="bullet">
        /// <item><c>artwork</c>: extract artwork embedded in the video file, if available, using the <c>/video/artwork</c> Robot.</item>
        /// <item><c>frame</c>: extract a frame from the video to preview its content, using the <c>/video/thumbs</c> Robot.</item>
        /// <item><c>clip</c>: extract a short clip from the video's beginning as an animated image to preview its first few seconds, 
        /// using the <c>/video/encode</c> Robot.</item>
        /// <item><c>icon</c>: generates a generic thumbnail featuring a category-specific icon and optionally the file's extension, 
        /// using the <c>/image/resize</c> Robot.</item>
        /// </list>
        /// Default: <c>["artwork", "frame", "icon"]</c>.
        /// </summary>
        public List<string> Video { get; set; }

        /// <summary>
        /// Available strategies are:
        /// <list type="bullet">
        /// <item><c>page</c>: display the first page of a text document or presentation, using the <c>/document/thumbs</c> (for PDFs) 
        /// and <c>/document/convert</c> Robots.</item>
        /// <item><c>icon</c>: generates a generic thumbnail featuring a category-specific icon and optionally the file's extension, 
        /// using the <c>/image/resize</c> Robot.</item>
        /// </list>
        /// Default: <c>["page", "icon"]</c>.
        /// </summary>
        public List<string> Document { get; set; }

        /// <summary>
        /// Available strategies are:
        /// <list type="bullet">
        /// <item><c>image</c>: resize the image to the specified dimensions and format, using the <c>/image/resize</c> Robot.</item>
        /// <item><c>icon</c>: generates a generic thumbnail featuring a category-specific icon and optionally the file's extension, 
        /// using the <c>/image/resize</c> Robot.</item>
        /// </list>
        /// Default: <c>["image", "icon"]</c>.
        /// </summary>
        public List<string> Image { get; set; }

        /// <summary>
        /// Available strategies are:
        /// <list type="bullet">
        /// <item><c>render</c>: render the HTML in a browser and take a screenshot of the web page, using the <c>/html/convert</c> Robot.</item>
        /// <item><c>icon</c>: generates a generic thumbnail featuring a category-specific icon and optionally the file's extension, 
        /// using the <c>/image/resize</c> Robot.</item>
        /// </list>
        /// Default: <c>["render", "icon"]</c>.
        /// </summary>
        public List<string> Webpage { get; set; }

        /// <summary>
        /// Available strategies are:
        /// <list type="bullet">
        /// <item><c>icon</c>: generates a generic thumbnail featuring a category-specific icon and optionally the file's extension, 
        /// using the <c>/image/resize</c> Robot.</item>
        /// </list>
        /// Default: <c>["icon"]</c>.
        /// </summary>
        public List<string> Archive { get; set; }

        /// <summary>
        /// Available strategies are:
        /// <list type="bullet">
        /// <item><c>icon</c>: generates a generic thumbnail featuring a category-specific icon and optionally the file's extension, 
        /// using the <c>/image/resize</c> Robot.</item>
        /// </list>
        /// Default: <c>["icon"]</c>.
        /// </summary>
        public List<string> Unknown { get; set; }
    }
}
