namespace Transloadit.Tests.Configuration
{
    public class TransloaditConfig
    {
        public const string Section = "Transloadit";

        public string AuthKey { get; set; }
        public string AuthSecret { get; set; }

        public string NotifyUrl { get; set; }
    }
}
