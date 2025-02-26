namespace Transloadit.Tests.Configuration
{
    public class TransloaditConfig
    {
        public const string Section = "Transloadit";

        public string AuthKey { get; set; }
        public string AuthSecret { get; set; }

        //any public webhook url is good enough for testing, like https://webhook.site or https://webhookdump.link
        public string NotifyUrl { get; set; }
    }
}
