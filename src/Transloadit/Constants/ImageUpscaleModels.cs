namespace Transloadit.Constants
{
    /// <summary>
    /// Contains supported AI models for <c>/image/upscale</c>.
    /// </summary>
    public static class ImageUpscaleModels
    {
        /// <summary>
        /// Real-ESRGAN model.
        /// </summary>
        public const string RealEsrgan = "nightmareai/real-esrgan";

        /// <summary>
        /// GFPGAN model.
        /// </summary>
        public const string Gfpgan = "tencentarc/gfpgan";

        /// <summary>
        /// CodeFormer model.
        /// </summary>
        public const string Codeformer = "sczhou/codeformer";
    }
}
