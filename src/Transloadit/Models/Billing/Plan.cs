using System;

namespace Transloadit.Models.Billing
{
    public class Plan
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public int PricePerMonth { get; set; }

        public int GbIncluded { get; set; }

        public int GbLimit { get; set; }

        public object FileSizeLimitInGb { get; set; }

        public int MaxJobsSimulteneous { get; set; }

        public int NumConcurrentPriorityJobs { get; set; }

        public int NumConcurrentBatchJobSlots { get; set; }

        public int NumSeats { get; set; }

        public int HasLifetimeLimit { get; set; }

        public int PricePerGb { get; set; }

        public object Tiers { get; set; }

        public string Currency { get; set; }

        public object UsdExchangeRate { get; set; }

        public int Published { get; set; }

        public int CanUseImageTurboMode { get; set; }

        public int CanUseVideoTurboMode { get; set; }

        public int CanUseAssemblyFieldsSearch { get; set; }

        public int ShouldWatermarkTranscodingResults { get; set; }

        public string Comments { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public DateTime? Deleted { get; set; }

        public object NumMachines { get; set; }

        public object PricePerMachine { get; set; }
    }
}
