using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Transloadit.Models.Billing
{
    public class BillingResponse : ResponseBase
    {
        public string InvoiceId { get; set; }

        public string To { get; set; }

        public string Email { get; set; }

        public string Month { get; set; }

        public DateTime Created { get; set; }

        public BillingPlan Plan { get; set; }

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
