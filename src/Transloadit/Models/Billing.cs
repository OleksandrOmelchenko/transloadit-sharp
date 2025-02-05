using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Transloadit.Models
{
    public class RobotBillingByRegionAndFactor
    {
        public int Factor { get; set; }

        [JsonProperty("rawGb")]
        public int RawGb { get; set; }

        [JsonProperty("gbFactorApplied")]
        public int GbFactorApplied { get; set; }

        [JsonProperty("freeGb")]
        public int FreeGb { get; set; }

        public string Region { get; set; }
    }

    public class RobotBilling
    {
        [JsonProperty("rawGb")]
        public int RawGb { get; set; }

        public int Gb { get; set; }

        [JsonProperty("freeGb")]
        public int FreeGb { get; set; }

        [JsonProperty("discountedGb")]
        public int DiscountedGb { get; set; }

        [JsonProperty("gbFactorApplied")]
        public int GbFactorApplied { get; set; }

        public int Factor { get; set; }

        public List<RobotBillingByRegionAndFactor> ByRegionAndFactor { get; set; }
    }

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

    public class BillingResponse : ResponseBase
    {
        public string InvoiceId { get; set; }

        public string To { get; set; }

        public string Email { get; set; }

        public string Month { get; set; }

        public DateTime Created { get; set; }

        public Plan Plan { get; set; }

        public string Currency { get; set; }

        public string Company { get; set; }

        public string ToContactEmailAddress { get; set; }

        [JsonProperty("address_1")]
        public string Address1 { get; set; }

        [JsonProperty("address_2")]
        public string Address2 { get; set; }

        public string Zip { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string CountryId { get; set; }

        public string Country { get; set; }

        public Dictionary<string, RobotBilling> Robots { get; set; }

        public int SubTotal { get; set; }

        public bool IsProrated { get; set; }

        public int UsedGb { get; set; }

        public int AdditionalGb { get; set; }

        public int AdditionalGbFee { get; set; }

        public int FinalSubTotal { get; set; }

        public int RewardDiscountPercent { get; set; }

        public int RewardDiscount { get; set; }

        public int CouponDiscountPercent { get; set; }

        public int CouponDiscount { get; set; }

        public int SignupDiscountPercent { get; set; }

        public int SignupDiscount { get; set; }

        public int Credit { get; set; }

        public int BillLimit { get; set; }

        public int VatRate { get; set; }

        public int Vat { get; set; }

        public bool ReverseChargeVat { get; set; }

        public string VatId { get; set; }

        public int Total { get; set; }
    }
}
