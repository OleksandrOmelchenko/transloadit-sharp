using Newtonsoft.Json;
using System;

namespace Transloadit.Models.Billing
{
    /// <summary>
    /// Represents billing plan data.
    /// </summary>
    public class BillingPlan
    {
        /// <summary>
        /// Plan id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Plan title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Slug.
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Price per month.
        /// </summary>
        [JsonProperty("price_per_month")]
        public decimal PricePerMonth { get; set; }

        /// <summary>
        /// Gigabytes included.
        /// </summary>
        [JsonProperty("gb_included")]
        public decimal GbIncluded { get; set; }

        /// <summary>
        /// Gigabyte limit.
        /// </summary>
        [JsonProperty("gb_limit")]
        public decimal? GbLimit { get; set; }

        /// <summary>
        /// File size limit in gigabytes.
        /// </summary>
        [JsonProperty("file_size_limit_in_gb")]
        public decimal? FileSizeLimitInGb { get; set; }

        /// <summary>
        /// Maximum amount of simultaneous jobs.
        /// </summary>
        [JsonProperty("max_jobs_simulteneous")]
        public int MaxJobsSimulteneous { get; set; }

        /// <summary>
        /// Amount of concurrent priority jobs.
        /// </summary>
        [JsonProperty("num_concurrent_priority_jobs")]
        public int NumConcurrentPriorityJobs { get; set; }

        /// <summary>
        /// Amount of councurrent batch job slots.
        /// </summary>
        [JsonProperty("num_concurrent_batch_job_slots")]
        public int NumConcurrentBatchJobSlots { get; set; }

        /// <summary>
        /// Seats number.
        /// </summary>
        [JsonProperty("num_seats")]
        public int NumSeats { get; set; }

        /// <summary>
        /// Whether has lifetime limit.
        /// </summary>
        [JsonProperty("has_lifetime_limit")]
        public int HasLifetimeLimit { get; set; }

        /// <summary>
        /// Price per gigabyte.
        /// </summary>
        [JsonProperty("price_per_gb")]
        public decimal PricePerGb { get; set; }

        //todo: type
        /// <summary>
        /// Billing tiers.
        /// </summary>
        [JsonProperty("tiers")]
        public object Tiers { get; set; }

        /// <summary>
        /// Currency code.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Exchange rate for USD.
        /// </summary>
        [JsonProperty("usd_exchange_rate")]
        public decimal? UsdExchangeRate { get; set; }

        /// <summary>
        /// Whether plan is published.
        /// </summary>
        [JsonProperty("published")]
        public int Published { get; set; }

        /// <summary>
        /// Whether image turbo mode can be used.
        /// </summary>
        [JsonProperty("can_use_image_turbo_mode")]
        public int CanUseImageTurboMode { get; set; }

        /// <summary>
        /// Whether video turbo mode can be used.
        /// </summary>
        [JsonProperty("can_use_video_turbo_mode")]
        public int CanUseVideoTurboMode { get; set; }

        /// <summary>
        /// Whether assembly fields search can be used.
        /// </summary>
        [JsonProperty("can_use_assembly_fields_search")]
        public int CanUseAssemblyFieldsSearch { get; set; }

        /// <summary>
        /// Whether to put watermark on transcoding results.
        /// </summary>
        [JsonProperty("should_watermark_transcoding_results")]
        public int ShouldWatermarkTranscodingResults { get; set; }

        /// <summary>
        /// Additional comments.
        /// </summary>
        [JsonProperty("comments")]
        public string Comments { get; set; }

        /// <summary>
        /// Plan creation date.
        /// </summary>
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Plan last modification date.
        /// </summary>
        [JsonProperty("modified")]
        public DateTimeOffset Modified { get; set; }

        /// <summary>
        /// Plan deletion date.
        /// </summary>
        [JsonProperty("deleted")]
        public DateTimeOffset? Deleted { get; set; }

        /// <summary>
        /// Amount of machines.
        /// </summary>
        [JsonProperty("num_machines")]
        public int? NumMachines { get; set; }

        /// <summary>
        /// Price per machine.
        /// </summary>
        [JsonProperty("price_per_machine")]
        public decimal? PricePerMachine { get; set; }
    }
}
