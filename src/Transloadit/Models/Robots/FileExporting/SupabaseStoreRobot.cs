using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/supabase/store</c> Robot.
    /// </summary>
    public class SupabaseStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// An object containing a list of headers to be set for this file on Supabase Spaces, such as <c>{ FileURL: "${file.url_name}" }</c>. 
        /// This can also include any available <a href="https://transloadit.com/docs/topics/assembly-instructions/#assembly-variables">Assembly variables</a>.
        /// Object Metadata can be specified using <c>x-amz-meta-*</c> headers.
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// This parameter provides signed URLs in the result JSON (in the <c>signed_ssl_url</c> property). The number that you set this parameter 
        /// to is the URL expiry time in seconds. If this parameter is not used, no URL signing is done.
        /// </summary>
        public int? SignUrlsFor { get; set; }

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
        /// Initializes <c>/supabase/store</c> Robot.
        /// </summary>
        public SupabaseStoreRobot()
        {
            Robot = "/supabase/store";
        }
    }
}
