using Newtonsoft.Json;
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
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Parent assembly id.
        /// </summary>
        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        /// <summary>
        /// Account id.
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Template id.
        /// </summary>
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// Template name.
        /// </summary>
        [JsonProperty("template_name")]
        public string TemplateName { get; set; }

        /// <summary>
        /// Server instance where the assembly is executed.
        /// </summary>
        [JsonProperty("instance")]
        public string Instance { get; set; }

        /// <summary>
        /// Notification url to which Transloadit will send Assembly status when the Assembly is completed.
        /// </summary>
        [JsonProperty("notify_url")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// Assembly redirect url.
        /// </summary>
        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Assembly upload files.
        /// </summary>
        [JsonProperty("files")]
        public string Files { get; set; }

        /// <summary>
        /// Assembly region.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// Assembly warning count.
        /// </summary>
        [JsonProperty("warning_count")]
        public int WarningCount { get; set; }

        /// <summary>
        /// Assembly input files number.
        /// </summary>
        [JsonProperty("num_input_files")]
        public int NumInputFiles { get; set; }

        /// <summary>
        /// Assembly execution duration.
        /// </summary>
        [JsonProperty("execution_duration")]
        public double ExecutionDuration { get; set; }

        /// <summary>
        /// Assembly execution start date.
        /// </summary>
        [JsonProperty("execution_start")]
        public DateTimeOffset ExecutionStart { get; set; }

        /// <summary>
        /// Assembly creation date.
        /// </summary>
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Assembly creation date as Unix epoch.
        /// </summary>
        [JsonProperty("created_ts")]
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
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Assembly id.
        /// </summary>
        [JsonProperty("assembly_id")]
        public string AssemblyId { get; set; }

        /// <summary>
        /// Assembly url.
        /// </summary>
        [JsonProperty("assembly_url")]
        public string AssemblyUrl { get; set; }

        /// <summary>
        /// Assembly SSL url.
        /// </summary>
        [JsonProperty("assembly_ssl_url")]
        public string AssemblySslUrl { get; set; }

        /// <summary>
        /// Notification url to which Transloadit will send Assembly status when the Assembly is completed.
        /// </summary>
        [JsonProperty("notify_url")]
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
        [JsonProperty("assembly_id")]
        public string AssemblyId { get; set; }

        /// <summary>
        /// Parent Assembly id.
        /// </summary>
        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        /// <summary>
        /// Account id.
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Account name.
        /// </summary>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// Account slug.
        /// </summary>
        [JsonProperty("account_slug")]
        public string AccountSlug { get; set; }

        /// <summary>
        /// Api auth key id.
        /// </summary>
        [JsonProperty("api_auth_key_id")]
        public string ApiAuthKeyId { get; set; }

        /// <summary>
        /// Template id.
        /// </summary>
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// Template name.
        /// </summary>
        [JsonProperty("template_name")]
        public string TemplateName { get; set; }

        /// <summary>
        /// Server instance where the assembly is executed.
        /// </summary>
        [JsonProperty("instance")]
        public string Instance { get; set; }

        /// <summary>
        /// Assembly region.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// Assembly url.
        /// </summary>
        [JsonProperty("assembly_url")]
        public string AssemblyUrl { get; set; }

        /// <summary>
        /// Assembly SSL url.
        /// </summary>
        [JsonProperty("assembly_ssl_url")]
        public string AssemblySslUrl { get; set; }

        /// <summary>
        /// Uppy server url.
        /// </summary>
        [JsonProperty("uppyserver_url")]
        public string UppyserverUrl { get; set; }

        /// <summary>
        /// Companion url.
        /// </summary>
        [JsonProperty("companion_url")]
        public string CompanionUrl { get; set; }

        /// <summary>
        /// Assembly websocket url.
        /// </summary>
        [JsonProperty("websocket_url")]
        public string WebsocketUrl { get; set; }

        /// <summary>
        /// Assembly update stream url.
        /// </summary>
        [JsonProperty("update_stream_url")]
        public string UpdateStreamUrl { get; set; }

        /// <summary>
        /// Assembly TUS url.
        /// </summary>
        [JsonProperty("tus_url")]
        public string TusUrl { get; set; }

        /// <summary>
        /// Bytes received.
        /// </summary>
        [JsonProperty("bytes_received")]
        public long BytesReceived { get; set; }

        /// <summary>
        /// Bytes expected.
        /// </summary>
        [JsonProperty("bytes_expected")]
        public long BytesExpected { get; set; }

        /// <summary>
        /// Upload duration.
        /// </summary>
        [JsonProperty("upload_duration")]
        public double UploadDuration { get; set; }

        /// <summary>
        /// Client agent.
        /// </summary>
        [JsonProperty("client_agent")]
        public string ClientAgent { get; set; }

        /// <summary>
        /// Client IP.
        /// </summary>
        [JsonProperty("client_ip")]
        public string ClientIp { get; set; }

        /// <summary>
        /// Client referrer.
        /// </summary>
        [JsonProperty("client_referer")]
        public string ClientReferer { get; set; }

        /// <summary>
        /// Transloadit client.
        /// </summary>
        [JsonProperty("transloadit_client")]
        public string TransloaditClient { get; set; }

        /// <summary>
        /// Assembly start date.
        /// </summary>
        [JsonProperty("start_date")]
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Whether upload metadata is extracted.
        /// </summary>
        [JsonProperty("upload_meta_data_extracted")]
        public bool UploadMetaDataExtracted { get; set; }

        /// <summary>
        /// Assembly warnings.
        /// </summary>
        [JsonProperty("warnings")]
        public List<AssemblyWarning> Warnings { get; set; }

        /// <summary>
        /// Whether Assembly is infinite.
        /// </summary>
        [JsonProperty("is_infinite")]
        public bool IsInfinite { get; set; }

        /// <summary>
        /// Whether Assembly has duplicate jobs.
        /// </summary>
        [JsonProperty("has_dupe_jobs")]
        public bool HasDupeJobs { get; set; }

        /// <summary>
        /// Assembly execution start date.
        /// </summary>
        [JsonProperty("execution_start")]
        public DateTimeOffset ExecutionStart { get; set; }

        /// <summary>
        /// Assembly execution duration.
        /// </summary>
        [JsonProperty("execution_duration")]
        public double ExecutionDuration { get; set; }

        /// <summary>
        /// Queue duration.
        /// </summary>
        [JsonProperty("queue_duration")]
        public double QueueDuration { get; set; }

        /// <summary>
        /// Job queue duration.
        /// </summary>
        [JsonProperty("jobs_queue_duration")]
        public double JobsQueueDuration { get; set; }

        /// <summary>
        /// Notification start date.
        /// </summary>
        [JsonProperty("notify_start")]
        public DateTimeOffset? NotifyStart { get; set; }

        /// <summary>
        /// Notification url to which Transloadit will send Assembly status when the Assembly is completed.
        /// </summary>
        [JsonProperty("notify_url")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// Notification response code.
        /// </summary>
        [JsonProperty("notify_response_code")]
        public int? NotifyResponseCode { get; set; }

        /// <summary>
        /// Notification response data.
        /// </summary>
        [JsonProperty("notify_response_data")]
        public string NotifyResponseData { get; set; }

        /// <summary>
        /// Notification duration.
        /// </summary>
        [JsonProperty("notify_duration")]
        public double? NotifyDuration { get; set; }

        /// <summary>
        /// Date of the last completed job.
        /// </summary>
        [JsonProperty("last_job_completed")]
        public DateTimeOffset? LastJobCompleted { get; set; }

        /// <summary>
        /// Assembly fields.
        /// </summary>
        [JsonProperty("fields")]
        public Dictionary<string, object> Fields { get; set; }

        //todo: figure out type
        /// <summary>
        /// Running jobs.
        /// </summary>
        [JsonProperty("running_jobs")]
        public List<object> RunningJobs { get; set; }

        /// <summary>
        /// Bytes usage.
        /// </summary>
        [JsonProperty("bytes_usage")]
        public long BytesUsage { get; set; }

        /// <summary>
        /// Usage tags.
        /// </summary>
        [JsonProperty("usage_tags")]
        public string UsageTags { get; set; }

        /// <summary>
        /// Executing jobs.
        /// </summary>
        [JsonProperty("executing_jobs")]
        public List<string> ExecutingJobs { get; set; }

        /// <summary>
        /// Started jobs.
        /// </summary>
        [JsonProperty("started_jobs")]
        public List<string> StartedJobs { get; set; }

        /// <summary>
        /// Parent Assembly status.
        /// </summary>
        [JsonProperty("parent_assembly_status")]
        public object ParentAssemblyStatus { get; set; }

        /// <summary>
        /// Assembly params.
        /// </summary>
        [JsonProperty("params")]
        public string Params { get; set; }

        /// <summary>
        /// Assembly template.
        /// </summary>
        [JsonProperty("template")]
        public string Template { get; set; }

        /// <summary>
        /// Merged params.
        /// </summary>
        [JsonProperty("merged_params")]
        public string MergedParams { get; set; }

        /// <summary>
        /// Number of expected TUS uploads.
        /// </summary>
        [JsonProperty("expected_tus_uploads")]
        public int ExpectedTusUploads { get; set; }

        /// <summary>
        /// Number of started TUS uploads.
        /// </summary>
        [JsonProperty("started_tus_uploads")]
        public int StartedTusUploads { get; set; }

        /// <summary>
        /// Number of finished TUS uploads.
        /// </summary>
        [JsonProperty("finished_tus_uploads")]
        public int FinishedTusUploads { get; set; }

        /// <summary>
        /// TUS uploads.
        /// </summary>
        [JsonProperty("tus_uploads")]
        public List<TusUpload> TusUploads { get; set; }

        /// <summary>
        /// Number of input files.
        /// </summary>
        [JsonProperty("num_input_files")]
        public int NumInputFiles { get; set; }

        /// <summary>
        /// File uploads.
        /// </summary>
        [JsonProperty("uploads")]
        public List<Upload> Uploads { get; set; }

        /// <summary>
        /// Assembly results.
        /// </summary>
        [JsonProperty("results")]
        public Dictionary<string, List<FileResult>> Results { get; set; }

        /// <summary>
        /// Build id.
        /// </summary>
        [JsonProperty("build_id")]
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
        [JsonProperty("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// Field name.
        /// </summary>
        [JsonProperty("fieldname")]
        public string Fieldname { get; set; }

        /// <summary>
        /// User metadate of the file.
        /// </summary>
        [JsonProperty("user_meta")]
        public Dictionary<string, object> UserMeta { get; set; }

        /// <summary>
        /// File size.
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// File offset.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Whether TUS upload is finished.
        /// </summary>
        [JsonProperty("finished")]
        public bool Finished { get; set; }

        /// <summary>
        /// Upload url.
        /// </summary>
        [JsonProperty("upload_url")]
        public string UploadUrl { get; set; }

        /// <summary>
        /// Local file path.
        /// </summary>
        [JsonProperty("local_path")]
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
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// File upload name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// File base name.
        /// </summary>
        [JsonProperty("basename")]
        public string Basename { get; set; }

        /// <summary>
        /// File extension.
        /// </summary>
        [JsonProperty("ext")]
        public string Ext { get; set; }

        /// <summary>
        /// File size.
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// File MIME type.
        /// </summary>
        [JsonProperty("mime")]
        public string Mime { get; set; }

        /// <summary>
        /// File type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// File field name.
        /// </summary>
        [JsonProperty("field")]
        public string Field { get; set; }

        /// <summary>
        /// File MD5 hash.
        /// </summary>
        [JsonProperty("md5hash")]
        public string Md5hash { get; set; }

        /// <summary>
        /// File original id.
        /// </summary>
        [JsonProperty("original_id")]
        public string OriginalId { get; set; }

        /// <summary>
        /// File original base name.
        /// </summary>
        [JsonProperty("original_basename")]
        public string OriginalBasename { get; set; }

        /// <summary>
        /// File original name.
        /// </summary>
        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        /// <summary>
        /// File original path.
        /// </summary>
        [JsonProperty("original_path")]
        public string OriginalPath { get; set; }

        /// <summary>
        /// File original MD5 hash.
        /// </summary>
        [JsonProperty("original_md5hash")]
        public string OriginalMd5hash { get; set; }

        /// <summary>
        /// Whether the upload is from batch import.
        /// </summary>
        [JsonProperty("from_batch_import")]
        public bool FromBatchImport { get; set; }

        /// <summary>
        /// Whether the upload is a TUS file.
        /// </summary>
        [JsonProperty("is_tus_file")]
        public bool IsTusFile { get; set; }

        /// <summary>
        /// TUS upload url.
        /// </summary>
        [JsonProperty("tus_upload_url")]
        public string TusUploadUrl { get; set; }

        /// <summary>
        /// Upload url.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Upload SSL url.
        /// </summary>
        [JsonProperty("ssl_url")]
        public string SslUrl { get; set; }

        /// <summary>
        /// Upload metadata.
        /// </summary>
        [JsonProperty("meta")]
        public Dictionary<string, object> Meta { get; set; }

        /// <summary>
        /// Upload user metadata.
        /// </summary>
        [JsonProperty("user_meta")]
        public Dictionary<string, object> UserMeta { get; set; }

        /// <summary>
        /// As alias.
        /// </summary>
        [JsonProperty("as")]
        public string As { get; set; }

        /// <summary>
        /// Upload queue name.
        /// </summary>
        [JsonProperty("queue")]
        public string Queue { get; set; }

        /// <summary>
        /// Upload queue time.
        /// </summary>
        [JsonProperty("queue_time")]
        public double QueueTime { get; set; }

        /// <summary>
        /// Upload execution time.
        /// </summary>
        [JsonProperty("exec_time")]
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
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// File result name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// File base name.
        /// </summary>
        [JsonProperty("basename")]
        public string Basename { get; set; }

        /// <summary>
        /// File extension.
        /// </summary>
        [JsonProperty("ext")]
        public string Ext { get; set; }

        /// <summary>
        /// File size.
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// File MIME type.
        /// </summary>
        [JsonProperty("mime")]
        public string Mime { get; set; }

        /// <summary>
        /// File type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// File field name.
        /// </summary>
        [JsonProperty("field")]
        public string Field { get; set; }

        /// <summary>
        /// File MD5 hash.
        /// </summary>
        [JsonProperty("md5hash")]
        public string Md5hash { get; set; }

        /// <summary>
        /// File original id.
        /// </summary>
        [JsonProperty("original_id")]
        public string OriginalId { get; set; }

        /// <summary>
        /// File original base name.
        /// </summary>
        [JsonProperty("original_basename")]
        public string OriginalBasename { get; set; }

        /// <summary>
        /// File original name.
        /// </summary>
        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        /// <summary>
        /// File original path.
        /// </summary>
        [JsonProperty("original_path")]
        public string OriginalPath { get; set; }

        /// <summary>
        /// File original MD5 hash.
        /// </summary>
        [JsonProperty("original_md5hash")]
        public string OriginalMd5hash { get; set; }

        /// <summary>
        /// Whether the result is from batch import.
        /// </summary>
        [JsonProperty("from_batch_import")]
        public bool FromBatchImport { get; set; }

        /// <summary>
        /// Whether the result is a TUS file.
        /// </summary>
        [JsonProperty("is_tus_file")]
        public bool IsTusFile { get; set; }

        /// <summary>
        /// TUS result url.
        /// </summary>
        [JsonProperty("tus_upload_url")]
        public string TusUploadUrl { get; set; }

        /// <summary>
        /// Result url.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Result SSL url.
        /// </summary>
        [JsonProperty("ssl_url")]
        public string SslUrl { get; set; }

        /// <summary>
        /// Result metadata.
        /// </summary>
        [JsonProperty("meta")]
        public Dictionary<string, object> Meta { get; set; }

        /// <summary>
        /// Result user metadata.
        /// </summary>
        [JsonProperty("user_meta")]
        public Dictionary<string, object> UserMeta { get; set; }

        /// <summary>
        /// As alias.
        /// </summary>
        [JsonProperty("as")]
        public string As { get; set; }

        /// <summary>
        /// Result queue name.
        /// </summary>
        [JsonProperty("queue")]
        public string Queue { get; set; }

        /// <summary>
        /// Result queue time.
        /// </summary>
        [JsonProperty("queue_time")]
        public double QueueTime { get; set; }

        /// <summary>
        /// Result execution time.
        /// </summary>
        [JsonProperty("exec_time")]
        public double ExecTime { get; set; }

        /// <summary>
        /// Processing cost.
        /// </summary>
        [JsonProperty("cost")]
        public int Cost { get; set; }

        /// <summary>
        /// Whether is temporary url.
        /// </summary>
        [JsonProperty("is_temp_url")]
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
        [JsonProperty("level")]
        public string Level { get; set; }

        /// <summary>
        /// Warning message.
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; }
    }
}
