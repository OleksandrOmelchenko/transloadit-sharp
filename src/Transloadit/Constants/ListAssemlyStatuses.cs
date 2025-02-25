namespace Transloadit.Constants
{
    /// <summary>
    /// Contains available Assembly statuses for filtering when retrieving Assembly list.
    /// </summary>
    public class ListAssemlyStatuses
    {
        /// <summary>
        /// <c>all</c> status.
        /// </summary>
        public const string All = "all";

        /// <summary>
        /// <c>uploading</c> status.
        /// </summary>
        public const string Uploading = "uploading";

        /// <summary>
        /// <c>executing</c> status.
        /// </summary>
        public const string Executing = "executing";

        /// <summary>
        /// <c>canceled</c> status.
        /// </summary>
        public const string Canceled = "canceled";

        /// <summary>
        /// <c>completed</c> status.
        /// </summary>
        public const string Completed = "completed";

        /// <summary>
        /// <c>failed</c> status.
        /// </summary>
        public const string Failed = "failed";

        /// <summary>
        /// <c>request_aborted</c> status.
        /// </summary>
        public const string RequestAborted = "request_aborted";
    }
}
