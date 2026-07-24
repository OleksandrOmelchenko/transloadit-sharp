using System;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Billing;

/// <summary>
/// Represents billing plan data.
/// </summary>
public class BillingPlan
{
    /// <summary>
    /// Plan id.
    /// </summary>
    [TransloaditJsonName("id")]
    public string Id { get; set; }

    /// <summary>
    /// Plan title.
    /// </summary>
    [TransloaditJsonName("title")]
    public string Title { get; set; }

    /// <summary>
    /// Slug.
    /// </summary>
    [TransloaditJsonName("slug")]
    public string Slug { get; set; }

    /// <summary>
    /// Price per month.
    /// </summary>
    [TransloaditJsonName("price_per_month")]
    public decimal PricePerMonth { get; set; }

    /// <summary>
    /// Gigabytes included.
    /// </summary>
    [TransloaditJsonName("gb_included")]
    public decimal GbIncluded { get; set; }

    /// <summary>
    /// Gigabyte limit.
    /// </summary>
    [TransloaditJsonName("gb_limit")]
    public decimal? GbLimit { get; set; }

    /// <summary>
    /// File size limit in gigabytes.
    /// </summary>
    [TransloaditJsonName("file_size_limit_in_gb")]
    public decimal? FileSizeLimitInGb { get; set; }

    /// <summary>
    /// Maximum amount of simultaneous jobs.
    /// </summary>
    [TransloaditJsonName("max_jobs_simulteneous")]
    public int MaxJobsSimulteneous { get; set; }

    /// <summary>
    /// Amount of concurrent priority jobs.
    /// </summary>
    [TransloaditJsonName("num_concurrent_priority_jobs")]
    public int NumConcurrentPriorityJobs { get; set; }

    /// <summary>
    /// Amount of councurrent batch job slots.
    /// </summary>
    [TransloaditJsonName("num_concurrent_batch_job_slots")]
    public int NumConcurrentBatchJobSlots { get; set; }

    /// <summary>
    /// Seats number.
    /// </summary>
    [TransloaditJsonName("num_seats")]
    public int NumSeats { get; set; }

    /// <summary>
    /// Whether has lifetime limit.
    /// </summary>
    [TransloaditJsonName("has_lifetime_limit")]
    public int HasLifetimeLimit { get; set; }

    /// <summary>
    /// Price per gigabyte.
    /// </summary>
    [TransloaditJsonName("price_per_gb")]
    public decimal PricePerGb { get; set; }

    //todo: type
    /// <summary>
    /// Billing tiers.
    /// </summary>
    [TransloaditJsonName("tiers")]
    public object Tiers { get; set; }

    /// <summary>
    /// Whether the plan uses flat-rate tiers (<c>1</c>) or not (<c>0</c>).
    /// </summary>
    [TransloaditJsonName("uses_flat_rate_tiers")]
    public int UsesFlatRateTiers { get; set; }

    /// <summary>
    /// Custom per-robot billing factors, when configured for the plan.
    /// </summary>
    [TransloaditJsonName("custom_robot_factors")]
    public object CustomRobotFactors { get; set; }

    /// <summary>
    /// Purchase order number associated with the plan, if any.
    /// </summary>
    [TransloaditJsonName("po_number")]
    public string PoNumber { get; set; }

    /// <summary>
    /// Currency code.
    /// </summary>
    [TransloaditJsonName("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Exchange rate for USD.
    /// </summary>
    [TransloaditJsonName("usd_exchange_rate")]
    public decimal? UsdExchangeRate { get; set; }

    /// <summary>
    /// Whether plan is published.
    /// </summary>
    [TransloaditJsonName("published")]
    public int Published { get; set; }

    /// <summary>
    /// Whether image turbo mode can be used.
    /// </summary>
    [TransloaditJsonName("can_use_image_turbo_mode")]
    public int CanUseImageTurboMode { get; set; }

    /// <summary>
    /// Whether video turbo mode can be used.
    /// </summary>
    [TransloaditJsonName("can_use_video_turbo_mode")]
    public int CanUseVideoTurboMode { get; set; }

    /// <summary>
    /// Whether assembly fields search can be used.
    /// </summary>
    [TransloaditJsonName("can_use_assembly_fields_search")]
    public int CanUseAssemblyFieldsSearch { get; set; }

    /// <summary>
    /// Whether to put watermark on transcoding results.
    /// </summary>
    [TransloaditJsonName("should_watermark_transcoding_results")]
    public int ShouldWatermarkTranscodingResults { get; set; }

    /// <summary>
    /// Additional comments.
    /// </summary>
    [TransloaditJsonName("comments")]
    public string Comments { get; set; }

    /// <summary>
    /// Plan creation date.
    /// </summary>
    [TransloaditJsonName("created")]
    public DateTimeOffset Created { get; set; }

    /// <summary>
    /// Plan last modification date.
    /// </summary>
    [TransloaditJsonName("modified")]
    public DateTimeOffset Modified { get; set; }

    /// <summary>
    /// Plan deletion date.
    /// </summary>
    [TransloaditJsonName("deleted")]
    public DateTimeOffset? Deleted { get; set; }

    /// <summary>
    /// Amount of machines.
    /// </summary>
    [TransloaditJsonName("num_machines")]
    public int? NumMachines { get; set; }

    /// <summary>
    /// Price per machine.
    /// </summary>
    [TransloaditJsonName("price_per_machine")]
    public decimal? PricePerMachine { get; set; }
}
