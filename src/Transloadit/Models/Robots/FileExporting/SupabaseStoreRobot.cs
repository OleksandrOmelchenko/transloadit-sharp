using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/supabase/store</c> Robot.
    /// </summary>
    public class SupabaseStoreRobot : StoreRobotBase
    {
        public Dictionary<string, string> Headers { get; set; }
        public int? SignUrlsFor { get; set; }

        /// <summary>
        /// Initializes <c>/supabase/store</c> Robot.
        /// </summary>
        public SupabaseStoreRobot()
        {
            Robot = "/supabase/store";
        }
    }
}
