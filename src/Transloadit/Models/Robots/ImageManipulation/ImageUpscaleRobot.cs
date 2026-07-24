using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.ImageManipulation;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/image-upscale/">/image/upscale</a> Robot.
/// </summary>
public class ImageUpscaleRobot : ProcessingRobotBase
{
    /// <summary>
    /// Specifies which Step(s) to use as input.
    /// </summary>
    [TransloaditJsonName("use")]
    public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

    /// <summary>
    /// AI model used for upscaling. One of <see cref="Constants.ImageUpscaleModels"/>.
    /// </summary>
    [TransloaditJsonName("model")]
    public string Model { get; set; }

    /// <summary>
    /// Upscaling factor.
    /// </summary>
    [TransloaditJsonName("scale")]
    public int? Scale { get; set; }

    /// <summary>
    /// Enables face enhancement.
    /// </summary>
    [TransloaditJsonName("face_enhance")]
    public bool? FaceEnhance { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/image-upscale/">/image/upscale</a> Robot.
    /// </summary>
    public ImageUpscaleRobot()
    {
        Robot = "/image/upscale";
    }
}
