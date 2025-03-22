namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/supabase/import</c> Robot.
    /// </summary>
    public class SupabaseImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Supabase bucket.
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// Supabase host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Supabase bucket region.
        /// </summary>
        public string BucketRegion { get; set; }

        /// <summary>
        /// Supabase key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Supabase secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Initializes <c>/supabase/import</c> Robot.
        /// </summary>
        public SupabaseImportRobot()
        {
            Robot = "/supabase/import";
        }
    }
}
