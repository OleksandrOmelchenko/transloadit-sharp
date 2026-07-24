using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.FileImporting;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/azure-import/">/azure/import</a> Robot.
/// </summary>
public class AzureImportRobot : ImportRobotBase
{
    /// <summary>
    /// A string token used for pagination. The returned files of one paginated call have the next page token inside of their 
    /// meta data, which needs to be used for the subsequent paging call.
    /// </summary>
    [TransloaditJsonName("next_page_token")]
    public string NextPageToken { get; set; }

    /// <summary>
    /// The pagination page size.
    /// <para>Default: <c>1000</c>.</para>
    /// </summary>
    [TransloaditJsonName("files_per_page")]
    public int? FilesPerPage { get; set; }

    /// <summary>
    /// Azure blob storage account.
    /// </summary>
    [TransloaditJsonName("account")]
    public string Account { get; set; }

    /// <summary>
    /// Azure blob storage key.
    /// </summary>
    [TransloaditJsonName("key")]
    public string Key { get; set; }

    /// <summary>
    /// Azure blob storage container.
    /// </summary>
    [TransloaditJsonName("container")]
    public string Container { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/azure-import/">/azure/import</a> Robot.
    /// </summary>
    public AzureImportRobot()
    {
        Robot = "/azure/import";
    }
}
