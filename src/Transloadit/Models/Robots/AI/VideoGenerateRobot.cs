using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.AI;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/video-generate/">/video/generate</a> Robot.
/// </summary>
public class VideoGenerateRobot : ProcessingRobotBase
{
    /// <summary>
    /// Specifies which Step(s) to use as input.
    /// </summary>
    [TransloaditJsonName("use")]
    public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

    /// <summary>
    /// The model to use.
    /// </summary>
    [TransloaditJsonName("model")]
    public string Model { get; set; }

    /// <summary>
    /// Required prompt describing desired video content.
    /// </summary>
    [TransloaditJsonName("prompt")]
    public string Prompt { get; set; }

    /// <summary>
    /// Output format such as <c>mp4</c> or <c>gif</c>.
    /// </summary>
    [TransloaditJsonName("format")]
    public string Format { get; set; }

    /// <summary>
    /// Deterministic generation seed.
    /// </summary>
    [TransloaditJsonName("seed")]
    public AnyOf<int, string> Seed { get; set; }

    /// <summary>
    /// Output aspect ratio.
    /// </summary>
    [TransloaditJsonName("aspect_ratio")]
    public string AspectRatio { get; set; }

    /// <summary>
    /// Output height in pixels.
    /// </summary>
    [TransloaditJsonName("height")]
    public AnyOf<int, string> Height { get; set; }

    /// <summary>
    /// Output width in pixels.
    /// </summary>
    [TransloaditJsonName("width")]
    public AnyOf<int, string> Width { get; set; }

    /// <summary>
    /// Generation style.
    /// </summary>
    [TransloaditJsonName("style")]
    public string Style { get; set; }

    /// <summary>
    /// Number of variants to generate.
    /// </summary>
    [TransloaditJsonName("num_outputs")]
    public AnyOf<int, string> NumOutputs { get; set; }

    /// <summary>
    /// Output duration in seconds.
    /// </summary>
    [TransloaditJsonName("duration")]
    public AnyOf<int, string> Duration { get; set; }

    /// <summary>
    /// Frames per second.
    /// </summary>
    [TransloaditJsonName("fps")]
    public AnyOf<int, string> Fps { get; set; }

    /// <summary>
    /// Motion intensity control.
    /// </summary>
    [TransloaditJsonName("motion_amount")]
    public AnyOf<int, string> MotionAmount { get; set; }

    /// <summary>
    /// Camera movement type.
    /// </summary>
    [TransloaditJsonName("camera_motion")]
    public string CameraMotion { get; set; }

    /// <summary>
    /// Negative prompt describing what to avoid.
    /// </summary>
    [TransloaditJsonName("negative_prompt")]
    public string NegativePrompt { get; set; }

    /// <summary>
    /// Reference adherence strength.
    /// </summary>
    [TransloaditJsonName("reference_strength")]
    public AnyOf<double, string> ReferenceStrength { get; set; }

    /// <summary>
    /// Provider override.
    /// </summary>
    [TransloaditJsonName("provider")]
    public string Provider { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/video-generate/">/video/generate</a> Robot.
    /// </summary>
    public VideoGenerateRobot()
    {
        Robot = "/video/generate";
    }
}
