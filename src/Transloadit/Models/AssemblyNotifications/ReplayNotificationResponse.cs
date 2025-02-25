namespace Transloadit.Models.AssemblyNotifications
{
    /// <summary>
    /// Represents replay Assembly notification response.
    /// </summary>
    public class ReplayNotificationResponse : ResponseBase
    {
    }

    /// <summary>
    /// Represents settings for Assembly notification replay.
    /// </summary>
    public class ReplayNotificationRequest : BaseParams
    {
        /// <summary>
        /// Notification url to which Transloadit will send Assembly status when the Assembly is completed.
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// Whether to wait for the notification to finish.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        public bool? Wait { get; set; }
    }
}
