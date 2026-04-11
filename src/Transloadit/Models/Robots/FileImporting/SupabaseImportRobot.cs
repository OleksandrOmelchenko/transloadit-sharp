using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/supabase-import/">/supabase/import</a> Robot.
    /// </summary>
    public class SupabaseImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Supabase bucket.
        /// </summary>
        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// Supabase host.
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// Supabase bucket region.
        /// </summary>
        [JsonProperty("bucket_region")]
        public string BucketRegion { get; set; }

        /// <summary>
        /// Supabase key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Supabase secret.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/supabase-import/">/supabase/import</a> Robot.
        /// </summary>
        public SupabaseImportRobot()
        {
            Robot = "/supabase/import";
        }
    }
}
