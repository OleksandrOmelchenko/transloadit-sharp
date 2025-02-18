namespace Transloadit.Constants
{
    /// <summary>
    /// Contains possible <c>ignore_errors</c> types.
    /// </summary>
    public static class IgnoreErrors
    {
        /// <summary>
        /// Including "meta" will cause the Robot to not stop the import (and the entire Assembly) when that happens
        /// </summary>
        public const string Meta = "meta";

        /// <summary>
        /// Including "import" will ensure the Robot does not cease to function on any import errors either.
        /// </summary>
        public const string Import = "import";
    }
}
