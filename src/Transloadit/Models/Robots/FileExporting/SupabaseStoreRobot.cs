using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    public class SupabaseStoreRobot : StoreRobotBase
    {
        public Dictionary<string, string> Headers { get; set; }
        public int? SignUrlsFor { get; set; }

        public SupabaseStoreRobot()
        {
            Robot = "/supabase/store";
        }
    }
}
