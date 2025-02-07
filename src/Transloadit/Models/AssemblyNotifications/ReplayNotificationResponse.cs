namespace Transloadit.Models.AssemblyNotifications
{
    public class ReplayNotificationResponse : ResponseBase
    {
    }

    public class ReplayNotificationRequest : BaseParams
    {
        public string NotifyUrl { get; set; }
        public bool? Wait { get; set; }
    }
}
