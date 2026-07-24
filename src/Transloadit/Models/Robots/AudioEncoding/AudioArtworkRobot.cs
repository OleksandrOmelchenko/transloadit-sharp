using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.AudioEncoding;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/audio-artwork/">/audio/artwork</a> Robot.
/// </summary>
public class AudioArtworkRobot : ProcessingRobotBase
{
    /// <summary>
    /// Specifies which Step(s) to use as input.
    /// </summary>
    [TransloaditJsonName("use")]
    public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

    /// <summary>
    /// What should be done with the audio file. A value of <c>extract</c> means audio artwork will be extracted. 
    /// A value of <c>insert</c> means the provided image will be inserted as audio artwork.
    /// <para>Default: <c>extract</c>.</para>
    /// </summary>
    [TransloaditJsonName("method")]
    public string Method { get; set; }

    /// <summary>
    /// Whether the original file should be transcoded into a new format if there is an issue with the original file.
    /// <para>Default: <c>false</c>.</para>
    /// </summary>
    [TransloaditJsonName("change_format_if_necessary")]
    public bool? ChangeFormatIfNecessary { get; set; }

    /// <summary>
    /// FFmpeg stack version. One of <see cref="Constants.FFMpegStack"/>: <c>v5.0.0</c> or <c>v6.0.0</c>.
    /// <para>Default: <c>v5.0.0</c>.</para>
    /// </summary>
    [TransloaditJsonName("ffmpeg_stack")]
    public string FfmpegStack { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/audio-artwork/">/audio/artwork</a> Robot.
    /// </summary>
    public AudioArtworkRobot()
    {
        Robot = "/audio/artwork";
    }
}
