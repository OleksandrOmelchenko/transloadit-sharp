using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Transloadit.Models.Assemblies
{
    public class Meta
    {
        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("date_file_modified")]
        public string DateFileModified { get; set; }

        [JsonProperty("aspect_ratio")]
        public double AspectRatio { get; set; }

        [JsonProperty("device_software")]
        public string DeviceSoftware { get; set; }

        [JsonProperty("has_clipping_path")]
        public bool HasClippingPath { get; set; }

        [JsonProperty("frame_count")]
        public int FrameCount { get; set; }

        [JsonProperty("colorspace")]
        public string Colorspace { get; set; }

        [JsonProperty("has_transparency")]
        public bool HasTransparency { get; set; }

        [JsonProperty("average_color")]
        public string AverageColor { get; set; }

        [JsonProperty("svgViewBoxWidth")]
        public object SvgViewBoxWidth { get; set; }

        [JsonProperty("svgViewBoxHeight")]
        public object SvgViewBoxHeight { get; set; }

        [JsonProperty("date_recorded")]
        public object DateRecorded { get; set; }

        [JsonProperty("date_file_created")]
        public object DateFileCreated { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("duration")]
        public object Duration { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("keywords")]
        public object Keywords { get; set; }

        [JsonProperty("aperture")]
        public object Aperture { get; set; }

        [JsonProperty("exposure_compensation")]
        public object ExposureCompensation { get; set; }

        [JsonProperty("exposure_mode")]
        public object ExposureMode { get; set; }

        [JsonProperty("exposure_time")]
        public object ExposureTime { get; set; }

        [JsonProperty("flash")]
        public object Flash { get; set; }

        [JsonProperty("focal_length")]
        public object FocalLength { get; set; }

        [JsonProperty("f_number")]
        public object FNumber { get; set; }

        [JsonProperty("iso")]
        public string Iso { get; set; }

        [JsonProperty("light_value")]
        public object LightValue { get; set; }

        [JsonProperty("metering_mode")]
        public object MeteringMode { get; set; }

        [JsonProperty("shutter_speed")]
        public object ShutterSpeed { get; set; }

        [JsonProperty("white_balance")]
        public object WhiteBalance { get; set; }

        [JsonProperty("device_name")]
        public string DeviceName { get; set; }

        [JsonProperty("device_vendor")]
        public string DeviceVendor { get; set; }

        [JsonProperty("latitude")]
        public object Latitude { get; set; }

        [JsonProperty("longitude")]
        public object Longitude { get; set; }

        [JsonProperty("orientation")]
        public string Orientation { get; set; }

        [JsonProperty("creator")]
        public string Creator { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("copyright_notice")]
        public string CopyrightNotice { get; set; }

        [JsonProperty("rights")]
        public object Rights { get; set; }

        [JsonProperty("dominant_colors")]
        public object DominantColors { get; set; }

        [JsonProperty("xp_title")]
        public string XpTitle { get; set; }

        [JsonProperty("xp_comment")]
        public string XpComment { get; set; }

        [JsonProperty("xp_keywords")]
        public object XpKeywords { get; set; }

        [JsonProperty("xp_subject")]
        public string XpSubject { get; set; }
    }

    public class Results
    {
    }

    public class AssemblyResponse : ResponseBase
    {
        [JsonProperty("assembly_id")]
        public string AssemblyId { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("account_slug")]
        public string AccountSlug { get; set; }

        [JsonProperty("api_auth_key_id")]
        public string ApiAuthKeyId { get; set; }

        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        [JsonProperty("template_name")]
        public string TemplateName { get; set; }

        [JsonProperty("instance")]
        public string Instance { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("assembly_url")]
        public string AssemblyUrl { get; set; }

        [JsonProperty("assembly_ssl_url")]
        public string AssemblySslUrl { get; set; }

        [JsonProperty("uppyserver_url")]
        public string UppyserverUrl { get; set; }

        [JsonProperty("companion_url")]
        public string CompanionUrl { get; set; }

        [JsonProperty("websocket_url")]
        public string WebsocketUrl { get; set; }

        [JsonProperty("update_stream_url")]
        public string UpdateStreamUrl { get; set; }

        [JsonProperty("tus_url")]
        public string TusUrl { get; set; }

        [JsonProperty("bytes_received")]
        public int BytesReceived { get; set; }

        [JsonProperty("bytes_expected")]
        public int BytesExpected { get; set; }

        [JsonProperty("upload_duration")]
        public double UploadDuration { get; set; }

        [JsonProperty("client_agent")]
        public string ClientAgent { get; set; }

        [JsonProperty("client_ip")]
        public string ClientIp { get; set; }

        [JsonProperty("client_referer")]
        public string ClientReferer { get; set; }

        [JsonProperty("transloadit_client")]
        public string TransloaditClient { get; set; }

        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("upload_meta_data_extracted")]
        public bool UploadMetaDataExtracted { get; set; }

        [JsonProperty("warnings")]
        public List<string> Warnings { get; set; }

        [JsonProperty("is_infinite")]
        public bool IsInfinite { get; set; }

        [JsonProperty("has_dupe_jobs")]
        public bool HasDupeJobs { get; set; }

        [JsonProperty("execution_start")]
        public string ExecutionStart { get; set; }

        [JsonProperty("execution_duration")]
        public double ExecutionDuration { get; set; }

        [JsonProperty("queue_duration")]
        public double QueueDuration { get; set; }

        [JsonProperty("jobs_queue_duration")]
        public int JobsQueueDuration { get; set; }

        [JsonProperty("notify_start")]
        public object NotifyStart { get; set; }

        [JsonProperty("notify_url")]
        public string NotifyUrl { get; set; }

        [JsonProperty("notify_response_code")]
        public object NotifyResponseCode { get; set; }

        [JsonProperty("notify_response_data")]
        public object NotifyResponseData { get; set; }

        [JsonProperty("notify_duration")]
        public object NotifyDuration { get; set; }

        [JsonProperty("last_job_completed")]
        public object LastJobCompleted { get; set; }

        [JsonProperty("fields")]
        public Dictionary<string, object> Fields { get; set; }

        [JsonProperty("running_jobs")]
        public List<object> RunningJobs { get; set; }

        [JsonProperty("bytes_usage")]
        public int BytesUsage { get; set; }

        [JsonProperty("usage_tags")]
        public string UsageTags { get; set; }

        [JsonProperty("executing_jobs")]
        public List<string> ExecutingJobs { get; set; }

        [JsonProperty("started_jobs")]
        public List<string> StartedJobs { get; set; }

        [JsonProperty("parent_assembly_status")]
        public object ParentAssemblyStatus { get; set; }

        [JsonProperty("params")]
        public string Params { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("merged_params")]
        public string MergedParams { get; set; }

        [JsonProperty("expected_tus_uploads")]
        public int ExpectedTusUploads { get; set; }

        [JsonProperty("started_tus_uploads")]
        public int StartedTusUploads { get; set; }

        [JsonProperty("finished_tus_uploads")]
        public int FinishedTusUploads { get; set; }

        [JsonProperty("tus_uploads")]
        public List<TusUpload> TusUploads { get; set; }

        [JsonProperty("num_input_files")]
        public int NumInputFiles { get; set; }

        [JsonProperty("uploads")]
        public List<Upload> Uploads { get; set; }

        [JsonProperty("results")]
        public Results Results { get; set; }

        [JsonProperty("build_id")]
        public string BuildId { get; set; }
    }

    public class TusUpload
    {
        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("fieldname")]
        public string Fieldname { get; set; }

        [JsonProperty("user_meta")]
        public UserMeta UserMeta { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("finished")]
        public bool Finished { get; set; }

        [JsonProperty("upload_url")]
        public string UploadUrl { get; set; }

        [JsonProperty("local_path")]
        public string LocalPath { get; set; }
    }

    public class Upload
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("basename")]
        public string Basename { get; set; }

        [JsonProperty("ext")]
        public string Ext { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("mime")]
        public string Mime { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("md5hash")]
        public string Md5hash { get; set; }

        [JsonProperty("original_id")]
        public string OriginalId { get; set; }

        [JsonProperty("original_basename")]
        public string OriginalBasename { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("original_path")]
        public string OriginalPath { get; set; }

        [JsonProperty("original_md5hash")]
        public string OriginalMd5hash { get; set; }

        [JsonProperty("from_batch_import")]
        public bool FromBatchImport { get; set; }

        [JsonProperty("is_tus_file")]
        public bool IsTusFile { get; set; }

        [JsonProperty("tus_upload_url")]
        public string TusUploadUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("ssl_url")]
        public string SslUrl { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("user_meta")]
        public UserMeta UserMeta { get; set; }

        [JsonProperty("as")]
        public object As { get; set; }

        [JsonProperty("queue")]
        public string Queue { get; set; }

        [JsonProperty("queue_time")]
        public int QueueTime { get; set; }

        [JsonProperty("exec_time")]
        public double ExecTime { get; set; }
    }

    public class UserMeta
    {
        [JsonProperty("filetype")]
        public string Filetype { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class AssemblyCompactResponse : ResponseBase
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string AccountId { get; set; }
        public string TemplateId { get; set; }
        public string Instance { get; set; }
        public string NotifyUrl { get; set; }
        public string RedirectUrl { get; set; }
        public string Files { get; set; }
        public string Region { get; set; }
        public int WarningCount { get; set; }
        public int NumInputFiles { get; set; }
        public double ExecutionDuration { get; set; }
        public DateTimeOffset ExecutionStart { get; set; }
        public DateTimeOffset Created { get; set; }
        public int CreatedTs { get; set; }
        public string TemplateName { get; set; }
    }
}
