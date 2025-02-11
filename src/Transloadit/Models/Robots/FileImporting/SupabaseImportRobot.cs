namespace Transloadit.Models.Robots.FileImporting
{
    public class SupabaseImportRobot : PaginatedImportRobotBase
    {
        public SupabaseImportRobot()
        {
            Robot = "/supabase/import";
        }
    }
}
