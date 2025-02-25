namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/supabase/import</c> Robot.
    /// </summary>
    public class SupabaseImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Initializes <c>/supabase/import</c> Robot.
        /// </summary>
        public SupabaseImportRobot()
        {
            Robot = "/supabase/import";
        }
    }
}
