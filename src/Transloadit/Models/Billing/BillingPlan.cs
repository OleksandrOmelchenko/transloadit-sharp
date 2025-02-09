using System;

namespace Transloadit.Models.Billing
{
    public class BillingPlan
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public decimal PricePerMonth { get; set; }

        public decimal GbIncluded { get; set; }

        public decimal? GbLimit { get; set; }

        public decimal? FileSizeLimitInGb { get; set; }

        public int MaxJobsSimulteneous { get; set; }

        public int NumConcurrentPriorityJobs { get; set; }

        public int NumConcurrentBatchJobSlots { get; set; }

        public int NumSeats { get; set; }

        public int HasLifetimeLimit { get; set; }

        public decimal PricePerGb { get; set; }

        public object Tiers { get; set; }

        public string Currency { get; set; }

        public decimal? UsdExchangeRate { get; set; }

        public int Published { get; set; }

        public int CanUseImageTurboMode { get; set; }

        public int CanUseVideoTurboMode { get; set; }

        public int CanUseAssemblyFieldsSearch { get; set; }

        public int ShouldWatermarkTranscodingResults { get; set; }

        public string Comments { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset Modified { get; set; }

        public DateTimeOffset? Deleted { get; set; }

        public int? NumMachines { get; set; }

        public decimal? PricePerMachine { get; set; }
    }
}
