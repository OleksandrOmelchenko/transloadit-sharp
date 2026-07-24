using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.AudioEncoding;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/audio-split/">/audio/split</a> Robot.
/// </summary>
public class AudioSplitRobot : ProcessingRobotBase
{
    /// <summary>
    /// Specifies which Step(s) to use as input.
    /// </summary>
    [TransloaditJsonName("use")]
    public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

    /// <summary>
    /// FFmpeg options merged over preset options.
    /// </summary>
    [TransloaditJsonName("ffmpeg")]
    public Dictionary<string, object> Ffmpeg { get; set; }

    /// <summary>
    /// FFmpeg stack version.
    /// </summary>
    [TransloaditJsonName("ffmpeg_stack")]
    public string FfmpegStack { get; set; }

    /// <summary>
    /// Audio encoding preset.
    /// </summary>
    [TransloaditJsonName("preset")]
    public string Preset { get; set; }

    /// <summary>
    /// Output bitrate.
    /// </summary>
    [TransloaditJsonName("bitrate")]
    public AnyOf<int, string> Bitrate { get; set; }

    /// <summary>
    /// Output sample rate.
    /// </summary>
    [TransloaditJsonName("sample_rate")]
    public AnyOf<int, string> SampleRate { get; set; }

    /// <summary>
    /// Audio segments to extract.
    /// </summary>
    [TransloaditJsonName("segments")]
    public List<AudioSplitSegment> Segments { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/audio-split/">/audio/split</a> Robot.
    /// </summary>
    public AudioSplitRobot()
    {
        Robot = "/audio/split";
    }
}

/// <summary>
/// Represents an audio split segment.
/// </summary>
public class AudioSplitSegment
{
    /// <summary>
    /// Segment start offset.
    /// </summary>
    [TransloaditJsonName("from")]
    public AnyOf<int, string> From { get; set; }

    /// <summary>
    /// Segment end offset.
    /// </summary>
    [TransloaditJsonName("to")]
    public AnyOf<int, string> To { get; set; }
}
