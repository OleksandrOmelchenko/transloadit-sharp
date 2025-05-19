using System;
using System.Collections.Generic;

namespace Transloadit.Models.Assemblies
{
    /// <summary>
    /// Represents compact assembly response when requesting a list of assemblies.
    /// </summary>
    public class AssemblyCompactResponse : ResponseBase
    {
        /// <summary>
        /// Assembly id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Parent assembly id.
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// Account id.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Template id.
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// Template name.
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// Server instance where the assembly is executed.
        /// </summary>
        public string Instance { get; set; }

        /// <summary>
        /// Notification url to which Transloadit will send Assembly status when the Assembly is completed.
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// Assembly redirect url.
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Assembly upload files.
        /// </summary>
        public string Files { get; set; }

        /// <summary>
        /// Assembly region.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Assembly warning count.
        /// </summary>
        public int WarningCount { get; set; }

        /// <summary>
        /// Assembly input files number.
        /// </summary>
        public int NumInputFiles { get; set; }

        /// <summary>
        /// Assembly execution duration.
        /// </summary>
        public double ExecutionDuration { get; set; }

        /// <summary>
        /// Assembly execution start date.
        /// </summary>
        public DateTimeOffset ExecutionStart { get; set; }

        /// <summary>
        /// Assembly creation date.
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Assembly creation date as Unix epoch.
        /// </summary>
        public long CreatedTs { get; set; }
    }

    /// <summary>
    /// Represents Assembly replay response.
    /// </summary>
    public class ReplayAssemblyResponse : ResponseBase
    {
        /// <summary>
        /// Whether replay request was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Assembly id.
        /// </summary>
        public string AssemblyId { get; set; }

        /// <summary>
        /// Assembly url.
        /// </summary>
        public string AssemblyUrl { get; set; }

        /// <summary>
        /// Assembly SSL url.
        /// </summary>
        public string AssemblySslUrl { get; set; }

        /// <summary>
        /// Notification url to which Transloadit will send Assembly status when the Assembly is completed.
        /// </summary>
        public string NotifyUrl { get; set; }
    }

    /// <summary>
    /// Represents assembly date.
    /// </summary>
    public class AssemblyResponse : ResponseBase
    {
        /// <summary>
        /// Assembly id.
        /// </summary>
        public string AssemblyId { get; set; }

        /// <summary>
        /// Parent Assembly id.
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// Account id.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Account name.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Account slug.
        /// </summary>
        public string AccountSlug { get; set; }

        /// <summary>
        /// Api auth key id.
        /// </summary>
        public string ApiAuthKeyId { get; set; }

        /// <summary>
        /// Template id.
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// Template name.
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// Server instance where the assembly is executed.
        /// </summary>
        public string Instance { get; set; }

        /// <summary>
        /// Assembly region.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Assembly url.
        /// </summary>
        public string AssemblyUrl { get; set; }

        /// <summary>
        /// Assembly SSL url.
        /// </summary>
        public string AssemblySslUrl { get; set; }

        /// <summary>
        /// Uppy server url.
        /// </summary>
        public string UppyserverUrl { get; set; }

        /// <summary>
        /// Companion url.
        /// </summary>
        public string CompanionUrl { get; set; }

        /// <summary>
        /// Assembly websocket url.
        /// </summary>
        public string WebsocketUrl { get; set; }

        /// <summary>
        /// Assembly update stream url.
        /// </summary>
        public string UpdateStreamUrl { get; set; }

        /// <summary>
        /// Assembly TUS url.
        /// </summary>
        public string TusUrl { get; set; }

        /// <summary>
        /// Bytes received.
        /// </summary>
        public long BytesReceived { get; set; }

        /// <summary>
        /// Bytes expected.
        /// </summary>
        public long BytesExpected { get; set; }

        /// <summary>
        /// Upload duration.
        /// </summary>
        public double UploadDuration { get; set; }

        /// <summary>
        /// Client agent.
        /// </summary>
        public string ClientAgent { get; set; }

        /// <summary>
        /// Client IP.
        /// </summary>
        public string ClientIp { get; set; }

        /// <summary>
        /// Client referrer.
        /// </summary>
        public string ClientReferer { get; set; }

        /// <summary>
        /// Transloadit client.
        /// </summary>
        public string TransloaditClient { get; set; }

        /// <summary>
        /// Assembly start date.
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Whether upload metadata is extracted.
        /// </summary>
        public bool UploadMetaDataExtracted { get; set; }

        /// <summary>
        /// Assembly warnings.
        /// </summary>
        public List<AssemblyWarning> Warnings { get; set; }

        /// <summary>
        /// Whether Assembly is infinite.
        /// </summary>
        public bool IsInfinite { get; set; }

        /// <summary>
        /// Whether Assembly has duplicate jobs.
        /// </summary>
        public bool HasDupeJobs { get; set; }

        /// <summary>
        /// Assembly execution start date.
        /// </summary>
        public DateTimeOffset ExecutionStart { get; set; }

        /// <summary>
        /// Assembly execution duration.
        /// </summary>
        public double ExecutionDuration { get; set; }

        /// <summary>
        /// Queue duration.
        /// </summary>
        public double QueueDuration { get; set; }

        /// <summary>
        /// Job queue duration.
        /// </summary>
        public double JobsQueueDuration { get; set; }

        /// <summary>
        /// Notification start date.
        /// </summary>
        public DateTimeOffset? NotifyStart { get; set; }

        /// <summary>
        /// Notification url to which Transloadit will send Assembly status when the Assembly is completed.
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// Notification response code.
        /// </summary>
        public int? NotifyResponseCode { get; set; }

        /// <summary>
        /// Notification response data.
        /// </summary>
        public string NotifyResponseData { get; set; }

        /// <summary>
        /// Notification duration.
        /// </summary>
        public double? NotifyDuration { get; set; }

        /// <summary>
        /// Date of the last completed job.
        /// </summary>
        public DateTimeOffset? LastJobCompleted { get; set; }

        /// <summary>
        /// Assembly fields.
        /// </summary>
        public Dictionary<string, object> Fields { get; set; }

        //todo: figure out type
        /// <summary>
        /// Running jobs.
        /// </summary>
        public List<object> RunningJobs { get; set; }

        /// <summary>
        /// Bytes usage.
        /// </summary>
        public long BytesUsage { get; set; }

        /// <summary>
        /// Usage tags.
        /// </summary>
        public string UsageTags { get; set; }

        /// <summary>
        /// Executing jobs.
        /// </summary>
        public List<string> ExecutingJobs { get; set; }

        /// <summary>
        /// Started jobs.
        /// </summary>
        public List<string> StartedJobs { get; set; }

        /// <summary>
        /// Parent Assembly status.
        /// </summary>
        public object ParentAssemblyStatus { get; set; }

        /// <summary>
        /// Assembly params.
        /// </summary>
        public string Params { get; set; }

        /// <summary>
        /// Assembly template.
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// Merged params.
        /// </summary>
        public string MergedParams { get; set; }

        /// <summary>
        /// Number of expected TUS uploads.
        /// </summary>
        public int ExpectedTusUploads { get; set; }

        /// <summary>
        /// Number of started TUS uploads.
        /// </summary>
        public int StartedTusUploads { get; set; }

        /// <summary>
        /// Number of finished TUS uploads.
        /// </summary>
        public int FinishedTusUploads { get; set; }

        /// <summary>
        /// TUS uploads.
        /// </summary>
        public List<TusUpload> TusUploads { get; set; }

        /// <summary>
        /// Number of input files.
        /// </summary>
        public int NumInputFiles { get; set; }

        /// <summary>
        /// File uploads.
        /// </summary>
        public List<Upload> Uploads { get; set; }

        /// <summary>
        /// Assembly results.
        /// </summary>
        public Dictionary<string, List<FileResult>> Results { get; set; }

        /// <summary>
        /// Build id.
        /// </summary>
        public string BuildId { get; set; }
    }

    /// <summary>
    /// Represents TUS upload.
    /// </summary>
    public class TusUpload
    {
        /// <summary>
        /// File name.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Field name.
        /// </summary>
        public string Fieldname { get; set; }

        /// <summary>
        /// User metadate of the file.
        /// </summary>
        public Dictionary<string, object> UserMeta { get; set; }

        /// <summary>
        /// File size.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// File offset.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Whether TUS upload is finished.
        /// </summary>
        public bool Finished { get; set; }

        /// <summary>
        /// Upload url.
        /// </summary>
        public string UploadUrl { get; set; }

        /// <summary>
        /// Local file path.
        /// </summary>
        public string LocalPath { get; set; }
    }

    /// <summary>
    /// Represents Assembly file upload.
    /// </summary>
    public class Upload
    {
        /// <summary>
        /// Upload id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// File upload name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// File base name.
        /// </summary>
        public string Basename { get; set; }

        /// <summary>
        /// File extension.
        /// </summary>
        public string Ext { get; set; }

        /// <summary>
        /// File size.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// File MIME type.
        /// </summary>
        public string Mime { get; set; }

        /// <summary>
        /// File type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// File field name.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// File MD5 hash.
        /// </summary>
        public string Md5hash { get; set; }

        /// <summary>
        /// File original id.
        /// </summary>
        public string OriginalId { get; set; }

        /// <summary>
        /// File original base name.
        /// </summary>
        public string OriginalBasename { get; set; }

        /// <summary>
        /// File original name.
        /// </summary>
        public string OriginalName { get; set; }

        /// <summary>
        /// File original path.
        /// </summary>
        public string OriginalPath { get; set; }

        /// <summary>
        /// File original MD5 hash.
        /// </summary>
        public string OriginalMd5hash { get; set; }

        /// <summary>
        /// Whether the upload is from batch import.
        /// </summary>
        public bool FromBatchImport { get; set; }

        /// <summary>
        /// Whether the upload is a TUS file.
        /// </summary>
        public bool IsTusFile { get; set; }

        /// <summary>
        /// TUS upload url.
        /// </summary>
        public string TusUploadUrl { get; set; }

        /// <summary>
        /// Upload url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Upload SSL url.
        /// </summary>
        public string SslUrl { get; set; }

        /// <summary>
        /// Upload metadata.
        /// </summary>
        public Dictionary<string, object> Meta { get; set; }

        /// <summary>
        /// Upload user metadata.
        /// </summary>
        public Dictionary<string, object> UserMeta { get; set; }

        /// <summary>
        /// As alias.
        /// </summary>
        public string As { get; set; }

        /// <summary>
        /// Upload queue name.
        /// </summary>
        public string Queue { get; set; }

        /// <summary>
        /// Upload queue time.
        /// </summary>
        public double QueueTime { get; set; }

        /// <summary>
        /// Upload execution time.
        /// </summary>
        public double ExecTime { get; set; }
    }

    /// <summary>
    /// Represents Assembly file result.
    /// </summary>
    public class FileResult
    {
        /// <summary>
        /// Result id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// File result name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// File base name.
        /// </summary>
        public string Basename { get; set; }

        /// <summary>
        /// File extension.
        /// </summary>
        public string Ext { get; set; }

        /// <summary>
        /// File size.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// File MIME type.
        /// </summary>
        public string Mime { get; set; }

        /// <summary>
        /// File type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// File field name.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// File MD5 hash.
        /// </summary>
        public string Md5hash { get; set; }

        /// <summary>
        /// File original id.
        /// </summary>
        public string OriginalId { get; set; }

        /// <summary>
        /// File original base name.
        /// </summary>
        public string OriginalBasename { get; set; }

        /// <summary>
        /// File original name.
        /// </summary>
        public string OriginalName { get; set; }

        /// <summary>
        /// File original path.
        /// </summary>
        public string OriginalPath { get; set; }

        /// <summary>
        /// File original MD5 hash.
        /// </summary>
        public string OriginalMd5hash { get; set; }

        /// <summary>
        /// Whether the result is from batch import.
        /// </summary>
        public bool FromBatchImport { get; set; }

        /// <summary>
        /// Whether the result is a TUS file.
        /// </summary>
        public bool IsTusFile { get; set; }

        /// <summary>
        /// TUS result url.
        /// </summary>
        public string TusUploadUrl { get; set; }

        /// <summary>
        /// Result url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Result SSL url.
        /// </summary>
        public string SslUrl { get; set; }

        /// <summary>
        /// Result metadata.
        /// </summary>
        public Dictionary<string, object> Meta { get; set; }

        /// <summary>
        /// Result user metadata.
        /// </summary>
        public Dictionary<string, object> UserMeta { get; set; }

        /// <summary>
        /// As alias.
        /// </summary>
        public string As { get; set; }

        /// <summary>
        /// Result queue name.
        /// </summary>
        public string Queue { get; set; }

        /// <summary>
        /// Result queue time.
        /// </summary>
        public double QueueTime { get; set; }

        /// <summary>
        /// Result execution time.
        /// </summary>
        public double ExecTime { get; set; }

        /// <summary>
        /// Processing cost.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Whether is temporary url.
        /// </summary>
        public bool IsTempUrl { get; set; }
    }

    /// <summary>
    /// Represents assembly warning.
    /// </summary>
    public class AssemblyWarning
    {
        /// <summary>
        /// Warning level.
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// Warning message.
        /// </summary>
        public string Msg { get; set; }
    }
}
