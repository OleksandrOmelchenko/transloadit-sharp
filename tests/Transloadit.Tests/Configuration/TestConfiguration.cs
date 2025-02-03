using Newtonsoft.Json;
using System;
using System.IO;

namespace Transloadit.Tests.Configuration
{
    internal class TestConfiguration
    {
        private TestConfiguration() { }

        public static TestConfiguration ReadFromAppSettings()
        {
            try
            {
                var raw = File.ReadAllText(@"appsettings.Tests.json");
                var config = JsonConvert.DeserializeObject<TestConfiguration>(raw);
                return config;
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException)
                {
                    throw new InvalidOperationException("Configuration file \"appsettings.Tests.json\" was not found." + Environment.NewLine +
                        "Create the file with the same structure as in \"appsettings.json\" and your configuration values.");
                }

                throw;
            }
        }

        public TransloaditConfig Transloadit { get; set; }
    }
}