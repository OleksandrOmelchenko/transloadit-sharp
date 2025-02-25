namespace Transloadit.Constants
{
    /// <summary>
    /// Contains available resize strategies for image processing.
    /// </summary>
    public static class ResizeStrategy
    {
        /// <summary>
        /// <c>fit</c> resize strategy.
        /// </summary>
        public const string Fit = "fit";

        /// <summary>
        /// <c>fillcrop</c> resize strategy.
        /// </summary>
        public const string FillCrop = "fillcrop";

        /// <summary>
        /// <c>min_fit</c> resize strategy.
        /// </summary>
        public const string MinFit = "min_fit";

        /// <summary>
        /// <c>pad</c> resize strategy.
        /// </summary>
        public const string Pad = "pad";

        /// <summary>
        /// <c>stretch</c> resize strategy.
        /// </summary>
        public const string Stretch = "stretch";

        /// <summary>
        /// <c>crop</c> resize strategy.
        /// </summary>
        public const string Crop = "crop";
    }
}
