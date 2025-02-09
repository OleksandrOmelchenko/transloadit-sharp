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

        public DateTimeOffset Created { get; set; }

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

        public decimal SubTotal { get; set; }

        public bool IsProrated { get; set; }

        public decimal UsedGb { get; set; }

        public decimal AdditionalGb { get; set; }

        public decimal AdditionalGbFee { get; set; }

        public decimal FinalSubTotal { get; set; }

        public decimal RewardDiscountPercent { get; set; }

        public decimal RewardDiscount { get; set; }

        public decimal CouponDiscountPercent { get; set; }

        public decimal CouponDiscount { get; set; }

        public decimal SignupDiscountPercent { get; set; }

        public decimal SignupDiscount { get; set; }

        public decimal Credit { get; set; }

        public decimal BillLimit { get; set; }

        public decimal VatRate { get; set; }

        public decimal Vat { get; set; }

        public bool ReverseChargeVat { get; set; }

        public string VatId { get; set; }

        public decimal Total { get; set; }
    }
}
