using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.Documents;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/document-convert/">/document/convert</a> Robot.
/// </summary>
public class DocumentConvertRobot : ProcessingRobotBase
{
    /// <summary>
    /// Specifies which Step(s) to use as input.
    /// </summary>
    [TransloaditJsonName("use")]
    public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

    /// <summary>
    /// The desired format for document conversion. One of <see cref="Constants.DocumentConvertFormats"/>: <c>doc</c>, <c>docx</c>, <c>html</c>, 
    /// <c>xhtml</c>, <c>xml</c>, <c>pdf</c>, <c>jpg</c>, <c>jpeg</c>, <c>gif</c>, <c>png</c>, <c>svg</c>, <c>ai</c>, <c>eps</c>, <c>ps</c>, 
    /// <c>txt</c>, <c>text</c>, <c>csv</c>, <c>xls</c>, <c>xlsx</c>, <c>xla</c>, <c>oda</c>, <c>odt</c>, <c>odd</c>, <c>ott</c>, <c>ppt</c>, 
    /// <c>pptx</c>, <c>ppz</c>, <c>pps</c>, <c>pot</c>, <c>rtf</c>, <c>rtx</c>, <c>latex</c>, <c>vtt</c> and <c>srt</c>.
    /// </summary>
    [TransloaditJsonName("format")]
    public string Format { get; set; }

    /// <summary>
    /// Markdown can be represented in several <a href="https://www.iana.org/assignments/markdown-variants/markdown-variants.xhtml">variants</a>, 
    /// so when using this Robot to transform Markdown into HTML please specify which revision is being used.
    /// <para>Default: <c>gfm</c>.</para>
    /// </summary>
    [TransloaditJsonName("markdown_format")]
    public string MarkdownFormat { get; set; }

    /// <summary>
    /// This parameter overhauls your Markdown files styling based on several canned presets.
    /// <para>Default: <c>github</c>.</para>
    /// </summary>
    [TransloaditJsonName("markdown_theme")]
    public string MarkdownTheme { get; set; }

    /// <summary>
    /// PDF Paper margins, separated by <c>,</c> and with units. The following unit values are supported: <c>px</c>, <c>in</c>, <c>cm</c>, <c>mm</c>.
    /// Currently this parameter is only supported when converting from <c>html</c>.
    /// <para>Default: <c>6.25mm,6.25mm,14.11mm,6.25mm</c>.</para>
    /// </summary>
    [TransloaditJsonName("pdf_margin")]
    public string PdfMargin { get; set; }

    /// <summary>
    /// Print PDF background graphics. Currently this parameter is only supported when converting from <c>html</c>.
    /// <para>Default: <c>true</c>.</para>
    /// </summary>
    [TransloaditJsonName("pdf_print_background")]
    public bool? PdfPrintBackground { get; set; }

    /// <summary>
    /// PDF paper format. Currently this parameter is only supported when converting from <c>html</c>.
    /// <para>Default: <c>Letter</c>.</para>
    /// </summary>
    [TransloaditJsonName("pdf_format")]
    public string PdfFormat { get; set; }

    /// <summary>
    /// Display PDF header and footer. Currently this parameter is only supported when converting from <c>html</c>.
    /// <para>Default: <c>false</c>.</para>
    /// </summary>
    [TransloaditJsonName("pdf_display_header_footer")]
    public bool? PdfDisplayHeaderFooter { get; set; }

    /// <summary>
    /// HTML template for the PDF print header. Currently this parameter is only supported when converting from <c>html</c>, and requires 
    /// <c>pdf_display_header_footer</c> to be enabled.
    /// <para>Should be valid HTML markup with following classes used to inject printing values into them:</para>
    /// <list type="bullet">
    /// <item><c>date</c> - formatted print date</item>
    /// <item><c>title</c> - document title</item>
    /// <item><c>url</c> - document location</item>
    /// <item><c>pageNumber</c> - current page number</item>
    /// <item><c>totalPages</c> - total pages in the document</item>
    /// </list>
    /// </summary>
    [TransloaditJsonName("pdf_header_template")]
    public string PdfHeaderTemplate { get; set; }

    /// <summary>
    /// HTML template for the PDF print footer. Should use the same format as the <c>pdf_header_template</c>. Currently this parameter 
    /// is only supported when converting from <c>html</c>, and requires <c>pdf_display_header_footer</c> to be enabled.
    /// </summary>
    [TransloaditJsonName("pdf_footer_template")]
    public string PdfFooterTemplate { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/document-convert/">/document/convert</a> Robot.
    /// </summary>
    public DocumentConvertRobot()
    {
        Robot = "/document/convert";
    }
}
