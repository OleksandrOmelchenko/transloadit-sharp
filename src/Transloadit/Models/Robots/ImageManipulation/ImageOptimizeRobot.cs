using System.Collections.Generic;

namespace Transloadit.Models.Robots.ImageManipulation
{
    /// <summary>
    /// Represents <c>/image/optimize</c> Robot.
    /// </summary>
    public class ImageOptimizeRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Provides different algorithms for better or worse compression for your images, but that run slower or faster. 
        /// The value <c>conversion-speed</c> will result in an average compression ratio of 18%. <c>compression-ratio</c> will result in an 
        /// average compression ratio of 31%.
        /// <para>Default: <c>compression-ratio</c>.</para>
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        /// Interlaces the image if set to <c>true</c>, which makes the result image load progressively in browsers. Instead of rendering 
        /// the image from top to bottom, the browser will first show a low-res blurry version of the image which is then quickly replaced 
        /// with the actual image as the data arrives. This greatly increases the user experience, but comes at a loss of about 10% of the 
        /// file size reduction.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? Progressive { get; set; }

        /// <summary>
        /// Specifies if the image's metadata should be preserved during the optimization, or not. If it is not preserved, the file size is even 
        /// further reduced. But be aware that this could strip a photographer's copyright information, which for obvious reasons can be frowned upon.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        public bool? PreserveMetaData { get; set; }

        /// <summary>
        /// If set to true this parameter tries to fix images that would otherwise make the underlying tool error out and thereby break your 
        /// Assemblies. This can sometimes result in a larger file size, though.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        public bool? FixBreakingImages { get; set; }

        /// <summary>
        /// Initializes <c>/image/optimize</c> Robot.
        /// </summary>
        public ImageOptimizeRobot()
        {
            Robot = "/image/optimize";
        }
    }
}
