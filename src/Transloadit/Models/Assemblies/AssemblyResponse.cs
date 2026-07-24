using Transloadit.Serialization.Attributes;
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
        [TransloaditJsonName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Parent assembly id.
        /// </summary>
        [TransloaditJsonName("parent_id")]
        public string ParentId { get; set; }

        /// <summary>
        /// Account id.
        /// </summary>
        [TransloaditJsonName("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Template id.
        /// </summary>
        [TransloaditJsonName("template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// Template name.
        /// </summary>
        [TransloaditJsonName("template_name")]
        public string TemplateName { get; set; }

        /// <summary>
        /// Server instance where the assembly is executed.
        /// </summary>
        [TransloaditJsonName("instance")]
        public string Instance { get; set; }

        /// <summary>
        /// Notification url to which Transloadit will send Assembly status when the Assembly is completed.
        /// </summary>
        [TransloaditJsonName("notify_url")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// Assembly redirect url.
        /// </summary>
        [TransloaditJsonName("redirect_url")]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Assembly upload files.
        /// </summary>
        [TransloaditJsonName("files")]
        public string Files { get; set; }

        /// <summary>
        /// Assembly region.
        /// </summary>
        [TransloaditJsonName("region")]
        public string Region { get; set; }

        /// <summary>
        /// Assembly warning count.
        /// </summary>
        [TransloaditJsonName("warning_count")]
        public int WarningCount { get; set; }

        /// <summary>
        /// Assembly input files number.
        /// </summary>
        [TransloaditJsonName("num_input_files")]
        public int NumInputFiles { get; set; }

        /// <summary>
        /// Assembly execution duration.
        /// </summary>
        [TransloaditJsonName("execution_duration")]
        public double? ExecutionDuration { get; set; }

        /// <summary>
        /// Assembly execution start date.
        /// </summary>
        [TransloaditJsonName("execution_start")]
        public DateTimeOffset? ExecutionStart { get; set; }

        /// <summary>
        /// Assembly creation date.
        /// </summary>
        [TransloaditJsonName("created")]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Assembly creation date as Unix epoch.
        /// </summary>
        [TransloaditJsonName("created_ts")]
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
        [TransloaditJsonName("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Assembly id.
        /// </summary>
        [TransloaditJsonName("assembly_id")]
        public string AssemblyId { get; set; }

        /// <summary>
        /// Assembly url.
        /// </summary>
        [TransloaditJsonName("assembly_url")]
        public string AssemblyUrl { get; set; }

        /// <summary>
        /// Assembly SSL url.
        /// </summary>
        [TransloaditJsonName("assembly_ssl_url")]
        public string AssemblySslUrl { get; set; }

        /// <summary>
        /// Notification url to which Transloadit will send Assembly status when the Assembly is completed.
        /// </summary>
        [TransloaditJsonName("notify_url")]
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
        [TransloaditJsonName("assembly_id")]
        public string AssemblyId { get; set; }

        /// <summary>
        /// Parent Assembly id.
        /// </summary>
        [TransloaditJsonName("parent_id")]
        public string ParentId { get; set; }

        /// <summary>
        /// Account id.
        /// </summary>
        [TransloaditJsonName("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Account name.
        /// </summary>
        [TransloaditJsonName("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// Account slug.
        /// </summary>
        [TransloaditJsonName("account_slug")]
        public string AccountSlug { get; set; }

        /// <summary>
        /// Api auth key id.
        /// </summary>
        [TransloaditJsonName("api_auth_key_id")]
        public string ApiAuthKeyId { get; set; }

        /// <summary>
        /// Template id.
        /// </summary>
        [TransloaditJsonName("template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// Template name.
        /// </summary>
        [TransloaditJsonName("template_name")]
        public string TemplateName { get; set; }

        /// <summary>
        /// Server instance where the assembly is executed.
        /// </summary>
        [TransloaditJsonName("instance")]
        public string Instance { get; set; }

        /// <summary>
        /// Assembly region.
        /// </summary>
        [TransloaditJsonName("region")]
        public string Region { get; set; }

        /// <summary>
        /// Assembly url.
        /// </summary>
        [TransloaditJsonName("assembly_url")]
        public string AssemblyUrl { get; set; }

        /// <summary>
        /// Assembly SSL url.
        /// </summary>
        [TransloaditJsonName("assembly_ssl_url")]
        public string AssemblySslUrl { get; set; }

        /// <summary>
        /// Uppy server url.
        /// </summary>
        [TransloaditJsonName("uppyserver_url")]
        public string UppyserverUrl { get; set; }

        /// <summary>
        /// Companion url.
        /// </summary>
        [TransloaditJsonName("companion_url")]
        public string CompanionUrl { get; set; }

        /// <summary>
        /// Assembly websocket url.
        /// </summary>
        [TransloaditJsonName("websocket_url")]
        public string WebsocketUrl { get; set; }

        /// <summary>
        /// Assembly update stream url.
        /// </summary>
        [TransloaditJsonName("update_stream_url")]
        public string UpdateStreamUrl { get; set; }

        /// <summary>
        /// Assembly TUS url.
        /// </summary>
        [TransloaditJsonName("tus_url")]
        public string TusUrl { get; set; }

        /// <summary>
        /// Bytes received.
        /// </summary>
        [TransloaditJsonName("bytes_received")]
        public long BytesReceived { get; set; }

        /// <summary>
        /// Bytes expected.
        /// </summary>
        [TransloaditJsonName("bytes_expected")]
        public long BytesExpected { get; set; }

        /// <summary>
        /// Upload duration.
        /// </summary>
        [TransloaditJsonName("upload_duration")]
        public double UploadDuration { get; set; }

        /// <summary>
        /// Client agent.
        /// </summary>
        [TransloaditJsonName("client_agent")]
        public string ClientAgent { get; set; }

        /// <summary>
        /// Client IP.
        /// </summary>
        [TransloaditJsonName("client_ip")]
        public string ClientIp { get; set; }

        /// <summary>
        /// Client referrer.
        /// </summary>
        [TransloaditJsonName("client_referer")]
        public string ClientReferer { get; set; }

        /// <summary>
        /// Transloadit client.
        /// </summary>
        [TransloaditJsonName("transloadit_client")]
        public string TransloaditClient { get; set; }

        /// <summary>
        /// Assembly start date.
        /// </summary>
        [TransloaditJsonName("start_date")]
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        /// Whether upload metadata is extracted.
        /// </summary>
        [TransloaditJsonName("upload_meta_data_extracted")]
        public bool UploadMetaDataExtracted { get; set; }

        /// <summary>
        /// Assembly warnings.
        /// </summary>
        [TransloaditJsonName("warnings")]
        public List<AssemblyWarning> Warnings { get; set; }

        /// <summary>
        /// Whether Assembly is infinite.
        /// </summary>
        [TransloaditJsonName("is_infinite")]
        public bool IsInfinite { get; set; }

        /// <summary>
        /// Whether Assembly has duplicate jobs.
        /// </summary>
        [TransloaditJsonName("has_dupe_jobs")]
        public bool HasDupeJobs { get; set; }

        /// <summary>
        /// Assembly execution start date.
        /// </summary>
        [TransloaditJsonName("execution_start")]
        public DateTimeOffset? ExecutionStart { get; set; }

        /// <summary>
        /// Assembly execution duration.
        /// </summary>
        [TransloaditJsonName("execution_duration")]
        public double? ExecutionDuration { get; set; }

        /// <summary>
        /// Number of errors that were ignored (for steps configured to ignore errors).
        /// </summary>
        [TransloaditJsonName("ignored_error_count")]
        public int IgnoredErrorCount { get; set; }

        /// <summary>
        /// The errors that were ignored (for steps configured to ignore errors).
        /// </summary>
        [TransloaditJsonName("ignored_errors")]
        public List<object> IgnoredErrors { get; set; }

        /// <summary>
        /// Queue duration.
        /// </summary>
        [TransloaditJsonName("queue_duration")]
        public double QueueDuration { get; set; }

        /// <summary>
        /// Job queue duration.
        /// </summary>
        [TransloaditJsonName("jobs_queue_duration")]
        public double JobsQueueDuration { get; set; }

        /// <summary>
        /// Notification start date.
        /// </summary>
        [TransloaditJsonName("notify_start")]
        public DateTimeOffset? NotifyStart { get; set; }

        /// <summary>
        /// Notification url to which Transloadit will send Assembly status when the Assembly is completed.
        /// </summary>
        [TransloaditJsonName("notify_url")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// Notification response code.
        /// </summary>
        [TransloaditJsonName("notify_response_code")]
        public int? NotifyResponseCode { get; set; }

        /// <summary>
        /// Notification response data.
        /// </summary>
        [TransloaditJsonName("notify_response_data")]
        public string NotifyResponseData { get; set; }

        /// <summary>
        /// Notification duration.
        /// </summary>
        [TransloaditJsonName("notify_duration")]
        public double? NotifyDuration { get; set; }

        /// <summary>
        /// Date of the last completed job.
        /// </summary>
        [TransloaditJsonName("last_job_completed")]
        public DateTimeOffset? LastJobCompleted { get; set; }

        /// <summary>
        /// Assembly fields.
        /// </summary>
        [TransloaditJsonName("fields")]
        public Dictionary<string, object> Fields { get; set; }

        //todo: figure out type
        /// <summary>
        /// Running jobs.
        /// </summary>
        [TransloaditJsonName("running_jobs")]
        public List<object> RunningJobs { get; set; }

        /// <summary>
        /// Bytes usage.
        /// </summary>
        [TransloaditJsonName("bytes_usage")]
        public long BytesUsage { get; set; }

        /// <summary>
        /// Usage tags.
        /// </summary>
        [TransloaditJsonName("usage_tags")]
        public string UsageTags { get; set; }

        /// <summary>
        /// Executing jobs.
        /// </summary>
        [TransloaditJsonName("executing_jobs")]
        public List<string> ExecutingJobs { get; set; }

        /// <summary>
        /// Started jobs.
        /// </summary>
        [TransloaditJsonName("started_jobs")]
        public List<string> StartedJobs { get; set; }

        /// <summary>
        /// Parent Assembly status.
        /// </summary>
        [TransloaditJsonName("parent_assembly_status")]
        public object ParentAssemblyStatus { get; set; }

        /// <summary>
        /// Assembly params.
        /// </summary>
        [TransloaditJsonName("params")]
        public string Params { get; set; }

        /// <summary>
        /// Assembly template.
        /// </summary>
        [TransloaditJsonName("template")]
        public string Template { get; set; }

        /// <summary>
        /// Merged params.
        /// </summary>
        [TransloaditJsonName("merged_params")]
        public string MergedParams { get; set; }

        /// <summary>
        /// Number of expected TUS uploads.
        /// </summary>
        [TransloaditJsonName("expected_tus_uploads")]
        public int ExpectedTusUploads { get; set; }

        /// <summary>
        /// Number of started TUS uploads.
        /// </summary>
        [TransloaditJsonName("started_tus_uploads")]
        public int StartedTusUploads { get; set; }

        /// <summary>
        /// Number of finished TUS uploads.
        /// </summary>
        [TransloaditJsonName("finished_tus_uploads")]
        public int FinishedTusUploads { get; set; }

        /// <summary>
        /// TUS uploads.
        /// </summary>
        [TransloaditJsonName("tus_uploads")]
        public List<TusUpload> TusUploads { get; set; }

        /// <summary>
        /// Number of input files.
        /// </summary>
        [TransloaditJsonName("num_input_files")]
        public int NumInputFiles { get; set; }

        /// <summary>
        /// File uploads.
        /// </summary>
        [TransloaditJsonName("uploads")]
        public List<Upload> Uploads { get; set; }

        /// <summary>
        /// Assembly results.
        /// </summary>
        [TransloaditJsonName("results")]
        public Dictionary<string, List<FileResult>> Results { get; set; }

        /// <summary>
        /// Build id.
        /// </summary>
        [TransloaditJsonName("build_id")]
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
        [TransloaditJsonName("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// Field name.
        /// </summary>
        [TransloaditJsonName("fieldname")]
        public string Fieldname { get; set; }

        /// <summary>
        /// User metadate of the file.
        /// </summary>
        [TransloaditJsonName("user_meta")]
        public Dictionary<string, object> UserMeta { get; set; }

        /// <summary>
        /// File size.
        /// </summary>
        [TransloaditJsonName("size")]
        public long Size { get; set; }

        /// <summary>
        /// File offset.
        /// </summary>
        [TransloaditJsonName("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Whether TUS upload is finished.
        /// </summary>
        [TransloaditJsonName("finished")]
        public bool Finished { get; set; }

        /// <summary>
        /// Upload url.
        /// </summary>
        [TransloaditJsonName("upload_url")]
        public string UploadUrl { get; set; }

        /// <summary>
        /// Local file path.
        /// </summary>
        [TransloaditJsonName("local_path")]
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
        [TransloaditJsonName("id")]
        public string Id { get; set; }

        /// <summary>
        /// File upload name.
        /// </summary>
        [TransloaditJsonName("name")]
        public string Name { get; set; }

        /// <summary>
        /// File base name.
        /// </summary>
        [TransloaditJsonName("basename")]
        public string Basename { get; set; }

        /// <summary>
        /// File extension.
        /// </summary>
        [TransloaditJsonName("ext")]
        public string Ext { get; set; }

        /// <summary>
        /// File size.
        /// </summary>
        [TransloaditJsonName("size")]
        public long Size { get; set; }

        /// <summary>
        /// File MIME type.
        /// </summary>
        [TransloaditJsonName("mime")]
        public string Mime { get; set; }

        /// <summary>
        /// File type.
        /// </summary>
        [TransloaditJsonName("type")]
        public string Type { get; set; }

        /// <summary>
        /// File field name.
        /// </summary>
        [TransloaditJsonName("field")]
        public string Field { get; set; }

        /// <summary>
        /// File MD5 hash.
        /// </summary>
        [TransloaditJsonName("md5hash")]
        public string Md5hash { get; set; }

        /// <summary>
        /// File original id.
        /// </summary>
        [TransloaditJsonName("original_id")]
        public string OriginalId { get; set; }

        /// <summary>
        /// File original base name.
        /// </summary>
        [TransloaditJsonName("original_basename")]
        public string OriginalBasename { get; set; }

        /// <summary>
        /// File original name.
        /// </summary>
        [TransloaditJsonName("original_name")]
        public string OriginalName { get; set; }

        /// <summary>
        /// File original path.
        /// </summary>
        [TransloaditJsonName("original_path")]
        public string OriginalPath { get; set; }

        /// <summary>
        /// File original MD5 hash.
        /// </summary>
        [TransloaditJsonName("original_md5hash")]
        public string OriginalMd5hash { get; set; }

        /// <summary>
        /// Whether the upload is from batch import.
        /// </summary>
        [TransloaditJsonName("from_batch_import")]
        public bool FromBatchImport { get; set; }

        /// <summary>
        /// Whether the upload is a TUS file.
        /// </summary>
        [TransloaditJsonName("is_tus_file")]
        public bool IsTusFile { get; set; }

        /// <summary>
        /// TUS upload url.
        /// </summary>
        [TransloaditJsonName("tus_upload_url")]
        public string TusUploadUrl { get; set; }

        /// <summary>
        /// Upload url.
        /// </summary>
        [TransloaditJsonName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Upload SSL url.
        /// </summary>
        [TransloaditJsonName("ssl_url")]
        public string SslUrl { get; set; }

        /// <summary>
        /// Upload metadata.
        /// </summary>
        [TransloaditJsonName("meta")]
        public Dictionary<string, object> Meta { get; set; }

        /// <summary>
        /// Upload user metadata.
        /// </summary>
        [TransloaditJsonName("user_meta")]
        public Dictionary<string, object> UserMeta { get; set; }

        /// <summary>
        /// As alias.
        /// </summary>
        [TransloaditJsonName("as")]
        public string As { get; set; }

        /// <summary>
        /// Upload queue name.
        /// </summary>
        [TransloaditJsonName("queue")]
        public string Queue { get; set; }

        /// <summary>
        /// Upload queue time.
        /// </summary>
        [TransloaditJsonName("queue_time")]
        public double QueueTime { get; set; }

        /// <summary>
        /// Upload execution time.
        /// </summary>
        [TransloaditJsonName("exec_time")]
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
        [TransloaditJsonName("id")]
        public string Id { get; set; }

        /// <summary>
        /// File result name.
        /// </summary>
        [TransloaditJsonName("name")]
        public string Name { get; set; }

        /// <summary>
        /// File base name.
        /// </summary>
        [TransloaditJsonName("basename")]
        public string Basename { get; set; }

        /// <summary>
        /// File extension.
        /// </summary>
        [TransloaditJsonName("ext")]
        public string Ext { get; set; }

        /// <summary>
        /// File size.
        /// </summary>
        [TransloaditJsonName("size")]
        public long Size { get; set; }

        /// <summary>
        /// File MIME type.
        /// </summary>
        [TransloaditJsonName("mime")]
        public string Mime { get; set; }

        /// <summary>
        /// File type.
        /// </summary>
        [TransloaditJsonName("type")]
        public string Type { get; set; }

        /// <summary>
        /// File field name.
        /// </summary>
        [TransloaditJsonName("field")]
        public string Field { get; set; }

        /// <summary>
        /// File MD5 hash.
        /// </summary>
        [TransloaditJsonName("md5hash")]
        public string Md5hash { get; set; }

        /// <summary>
        /// File original id.
        /// </summary>
        [TransloaditJsonName("original_id")]
        public string OriginalId { get; set; }

        /// <summary>
        /// File original base name.
        /// </summary>
        [TransloaditJsonName("original_basename")]
        public string OriginalBasename { get; set; }

        /// <summary>
        /// File original name.
        /// </summary>
        [TransloaditJsonName("original_name")]
        public string OriginalName { get; set; }

        /// <summary>
        /// File original path.
        /// </summary>
        [TransloaditJsonName("original_path")]
        public string OriginalPath { get; set; }

        /// <summary>
        /// File original MD5 hash.
        /// </summary>
        [TransloaditJsonName("original_md5hash")]
        public string OriginalMd5hash { get; set; }

        /// <summary>
        /// Whether the result is from batch import.
        /// </summary>
        [TransloaditJsonName("from_batch_import")]
        public bool FromBatchImport { get; set; }

        /// <summary>
        /// Whether the result is a TUS file.
        /// </summary>
        [TransloaditJsonName("is_tus_file")]
        public bool IsTusFile { get; set; }

        /// <summary>
        /// TUS result url.
        /// </summary>
        [TransloaditJsonName("tus_upload_url")]
        public string TusUploadUrl { get; set; }

        /// <summary>
        /// Result url.
        /// </summary>
        [TransloaditJsonName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Result SSL url.
        /// </summary>
        [TransloaditJsonName("ssl_url")]
        public string SslUrl { get; set; }

        /// <summary>
        /// Result metadata.
        /// </summary>
        [TransloaditJsonName("meta")]
        public Dictionary<string, object> Meta { get; set; }

        /// <summary>
        /// Result user metadata.
        /// </summary>
        [TransloaditJsonName("user_meta")]
        public Dictionary<string, object> UserMeta { get; set; }

        /// <summary>
        /// As alias.
        /// </summary>
        [TransloaditJsonName("as")]
        public string As { get; set; }

        /// <summary>
        /// Result queue name.
        /// </summary>
        [TransloaditJsonName("queue")]
        public string Queue { get; set; }

        /// <summary>
        /// Result queue time.
        /// </summary>
        [TransloaditJsonName("queue_time")]
        public double QueueTime { get; set; }

        /// <summary>
        /// Result execution time.
        /// </summary>
        [TransloaditJsonName("exec_time")]
        public double ExecTime { get; set; }

        /// <summary>
        /// Processing cost.
        /// </summary>
        [TransloaditJsonName("cost")]
        public int Cost { get; set; }

        /// <summary>
        /// Whether is temporary url.
        /// </summary>
        [TransloaditJsonName("is_temp_url")]
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
        [TransloaditJsonName("level")]
        public string Level { get; set; }

        /// <summary>
        /// Warning message.
        /// </summary>
        [TransloaditJsonName("msg")]
        public string Msg { get; set; }
    }
}
