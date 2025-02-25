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
        public string Id { get; set; }

        /// <summary>
        /// Plan title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Slug.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Price per month.
        /// </summary>
        public decimal PricePerMonth { get; set; }

        /// <summary>
        /// Gigabytes included.
        /// </summary>
        public decimal GbIncluded { get; set; }

        /// <summary>
        /// Gigabyte limit.
        /// </summary>
        public decimal? GbLimit { get; set; }

        /// <summary>
        /// File size limit in gigabytes.
        /// </summary>
        public decimal? FileSizeLimitInGb { get; set; }

        /// <summary>
        /// Maximum amount of simultaneous jobs.
        /// </summary>
        public int MaxJobsSimulteneous { get; set; }

        /// <summary>
        /// Amount of concurrent priority jobs.
        /// </summary>
        public int NumConcurrentPriorityJobs { get; set; }

        /// <summary>
        /// Amount of councurrent batch job slots.
        /// </summary>
        public int NumConcurrentBatchJobSlots { get; set; }

        /// <summary>
        /// Seats number.
        /// </summary>
        public int NumSeats { get; set; }

        /// <summary>
        /// Whether has lifetime limit.
        /// </summary>
        public int HasLifetimeLimit { get; set; }

        /// <summary>
        /// Price per gigabyte.
        /// </summary>
        public decimal PricePerGb { get; set; }

        public object Tiers { get; set; }

        /// <summary>
        /// Currency code.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Exchange rate for USD.
        /// </summary>
        public decimal? UsdExchangeRate { get; set; }

        /// <summary>
        /// Whether plan is published.
        /// </summary>
        public int Published { get; set; }

        /// <summary>
        /// Whether image turbo mode can be used.
        /// </summary>
        public int CanUseImageTurboMode { get; set; }

        /// <summary>
        /// Whether video turbo mode can be used.
        /// </summary>
        public int CanUseVideoTurboMode { get; set; }

        /// <summary>
        /// Whether assembly fields search can be used.
        /// </summary>
        public int CanUseAssemblyFieldsSearch { get; set; }

        /// <summary>
        /// Whether to put watermark on transcoding results.
        /// </summary>
        public int ShouldWatermarkTranscodingResults { get; set; }

        /// <summary>
        /// Additional comments.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Plan creation date.
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Plan last modification date.
        /// </summary>
        public DateTimeOffset Modified { get; set; }

        /// <summary>
        /// Plan deletion date.
        /// </summary>
        public DateTimeOffset? Deleted { get; set; }

        /// <summary>
        /// Amount of machines.
        /// </summary>
        public int? NumMachines { get; set; }

        /// <summary>
        /// Price per machine.
        /// </summary>
        public decimal? PricePerMachine { get; set; }
    }
}
