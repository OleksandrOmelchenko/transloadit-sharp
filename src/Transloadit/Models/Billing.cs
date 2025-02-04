using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Transloadit.Models
{
    public class RobotBilling
    {
        [JsonProperty("rawGb")]
        public int RawGb { get; set; }

        [JsonProperty("gb")]
        public int Gb { get; set; }

        [JsonProperty("freeGb")]
        public int FreeGb { get; set; }

        [JsonProperty("gbFactorApplied")]
        public int GbFactorApplied { get; set; }

        [JsonProperty("factor")]
        public int Factor { get; set; }
    }

    public class Plan
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("price_per_month")]
        public int PricePerMonth { get; set; }

        [JsonProperty("gb_included")]
        public int GbIncluded { get; set; }

        [JsonProperty("gb_limit")]
        public int GbLimit { get; set; }

        [JsonProperty("file_size_limit_in_gb")]
        public object FileSizeLimitInGb { get; set; }

        [JsonProperty("max_jobs_simulteneous")]
        public int MaxJobsSimulteneous { get; set; }

        [JsonProperty("num_concurrent_priority_jobs")]
        public int NumConcurrentPriorityJobs { get; set; }

        [JsonProperty("num_concurrent_batch_job_slots")]
        public int NumConcurrentBatchJobSlots { get; set; }

        [JsonProperty("num_seats")]
        public int NumSeats { get; set; }

        [JsonProperty("has_lifetime_limit")]
        public int HasLifetimeLimit { get; set; }

        [JsonProperty("price_per_gb")]
        public int PricePerGb { get; set; }

        [JsonProperty("tiers")]
        public object Tiers { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("usd_exchange_rate")]
        public object UsdExchangeRate { get; set; }

        [JsonProperty("published")]
        public int Published { get; set; }

        [JsonProperty("can_use_image_turbo_mode")]
        public int CanUseImageTurboMode { get; set; }

        [JsonProperty("can_use_video_turbo_mode")]
        public int CanUseVideoTurboMode { get; set; }

        [JsonProperty("can_use_assembly_fields_search")]
        public int CanUseAssemblyFieldsSearch { get; set; }

        [JsonProperty("should_watermark_transcoding_results")]
        public int ShouldWatermarkTranscodingResults { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("deleted")]
        public object Deleted { get; set; }

        [JsonProperty("num_machines")]
        public object NumMachines { get; set; }

        [JsonProperty("price_per_machine")]
        public object PricePerMachine { get; set; }
    }

    public class BillingResponse
    {
        [JsonProperty("ok")]
        public string Ok { get; set; }

        [JsonProperty("invoice_id")]
        public object InvoiceId { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("email")]
        public object Email { get; set; }

        [JsonProperty("month")]
        public string Month { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("plan")]
        public Plan Plan { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("to_contact_email_address")]
        public string ToContactEmailAddress { get; set; }

        [JsonProperty("address_1")]
        public string Address1 { get; set; }

        [JsonProperty("address_2")]
        public string Address2 { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country_id")]
        public string CountryId { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("robots")]
        public Dictionary<string, RobotBilling> Robots { get; set; }

        [JsonProperty("sub_total")]
        public int SubTotal { get; set; }

        [JsonProperty("is_prorated")]
        public bool IsProrated { get; set; }

        [JsonProperty("used_gb")]
        public int UsedGb { get; set; }

        [JsonProperty("additional_gb")]
        public int AdditionalGb { get; set; }

        [JsonProperty("additional_gb_fee")]
        public int AdditionalGbFee { get; set; }

        [JsonProperty("final_sub_total")]
        public int FinalSubTotal { get; set; }

        [JsonProperty("reward_discount_percent")]
        public int RewardDiscountPercent { get; set; }

        [JsonProperty("reward_discount")]
        public int RewardDiscount { get; set; }

        [JsonProperty("coupon_discount_percent")]
        public int CouponDiscountPercent { get; set; }

        [JsonProperty("coupon_discount")]
        public int CouponDiscount { get; set; }

        [JsonProperty("signup_discount_percent")]
        public int SignupDiscountPercent { get; set; }

        [JsonProperty("signup_discount")]
        public int SignupDiscount { get; set; }

        [JsonProperty("credit")]
        public int Credit { get; set; }

        [JsonProperty("bill_limit")]
        public int BillLimit { get; set; }

        [JsonProperty("vat_rate")]
        public int VatRate { get; set; }

        [JsonProperty("vat")]
        public int Vat { get; set; }

        [JsonProperty("reverse_charge_vat")]
        public bool ReverseChargeVat { get; set; }

        [JsonProperty("vat_id")]
        public string VatId { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
