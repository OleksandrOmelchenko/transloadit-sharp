using System;
using System.Collections.Generic;

namespace Transloadit.Models.Assemblies
{
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

    public class AssemblyResponse : ResponseBase
    {
        public string AssemblyId { get; set; }

        public string ParentId { get; set; }

        public string AccountId { get; set; }

        public string AccountName { get; set; }

        public string AccountSlug { get; set; }

        public string ApiAuthKeyId { get; set; }

        public string TemplateId { get; set; }

        public string TemplateName { get; set; }

        public string Instance { get; set; }

        public string Region { get; set; }

        public string AssemblyUrl { get; set; }

        public string AssemblySslUrl { get; set; }

        public string UppyserverUrl { get; set; }

        public string CompanionUrl { get; set; }

        public string WebsocketUrl { get; set; }

        public string UpdateStreamUrl { get; set; }

        public string TusUrl { get; set; }

        public int BytesReceived { get; set; }

        public int BytesExpected { get; set; }

        public double UploadDuration { get; set; }

        public string ClientAgent { get; set; }

        public string ClientIp { get; set; }

        public string ClientReferer { get; set; }

        public string TransloaditClient { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public bool UploadMetaDataExtracted { get; set; }

        public List<string> Warnings { get; set; }

        public bool IsInfinite { get; set; }

        public bool HasDupeJobs { get; set; }

        public DateTimeOffset ExecutionStart { get; set; }

        public double ExecutionDuration { get; set; }

        public double QueueDuration { get; set; }

        public double JobsQueueDuration { get; set; }

        public object NotifyStart { get; set; }

        public string NotifyUrl { get; set; }

        public object NotifyResponseCode { get; set; }

        public object NotifyResponseData { get; set; }

        public object NotifyDuration { get; set; }

        public object LastJobCompleted { get; set; }

        public Dictionary<string, object> Fields { get; set; }

        public List<object> RunningJobs { get; set; }

        public int BytesUsage { get; set; }

        public string UsageTags { get; set; }

        public List<string> ExecutingJobs { get; set; }

        public List<string> StartedJobs { get; set; }

        public object ParentAssemblyStatus { get; set; }

        public string Params { get; set; }

        public string Template { get; set; }

        public string MergedParams { get; set; }

        public int ExpectedTusUploads { get; set; }

        public int StartedTusUploads { get; set; }

        public int FinishedTusUploads { get; set; }

        public List<TusUpload> TusUploads { get; set; }

        public int NumInputFiles { get; set; }

        public List<Upload> Uploads { get; set; }

        public Dictionary<string, object> Results { get; set; }

        public string BuildId { get; set; }
    }

    public class TusUpload
    {
        public string Filename { get; set; }

        public string Fieldname { get; set; }

        public Dictionary<string, object> UserMeta { get; set; }

        public int Size { get; set; }

        public int Offset { get; set; }

        public bool Finished { get; set; }

        public string UploadUrl { get; set; }

        public string LocalPath { get; set; }
    }

    public class Upload
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Basename { get; set; }

        public string Ext { get; set; }

        public int Size { get; set; }

        public string Mime { get; set; }

        public string Type { get; set; }

        public string Field { get; set; }

        public string Md5hash { get; set; }

        public string OriginalId { get; set; }

        public string OriginalBasename { get; set; }

        public string OriginalName { get; set; }

        public string OriginalPath { get; set; }

        public string OriginalMd5hash { get; set; }

        public bool FromBatchImport { get; set; }

        public bool IsTusFile { get; set; }

        public string TusUploadUrl { get; set; }

        public string Url { get; set; }

        public string SslUrl { get; set; }

        public Dictionary<string, object> Meta { get; set; }

        public Dictionary<string, object> UserMeta { get; set; }

        public string As { get; set; }

        public string Queue { get; set; }

        public double QueueTime { get; set; }

        public double ExecTime { get; set; }
    }
}
