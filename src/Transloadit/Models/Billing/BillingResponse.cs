using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Transloadit.Models.Billing
{
    /// <summary>
    /// Represents billing data.
    /// </summary>
    public class BillingResponse : ResponseBase
    {
        /// <summary>
        /// Invoice id.
        /// </summary>
        [JsonProperty("invoice_id")]
        public string InvoiceId { get; set; }

        /// <summary>
        /// Account name.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Account email.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Billing month.
        /// </summary>
        [JsonProperty("month")]
        public string Month { get; set; }

        /// <summary>
        /// Invoice creation date.
        /// </summary>
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Billing plan.
        /// </summary>
        [JsonProperty("plan")]
        public BillingPlan Plan { get; set; }

        /// <summary>
        /// Currency.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Company name.
        /// </summary>
        [JsonProperty("company")]
        public string Company { get; set; }

        /// <summary>
        /// Contact email address.
        /// </summary>
        [JsonProperty("to_contact_email_address")]
        public string ToContactEmailAddress { get; set; }

        /// <summary>
        /// Address line 1.
        /// </summary>
        [JsonProperty("address_1")]
        public string Address1 { get; set; }

        /// <summary>
        /// Address line 2.
        /// </summary>
        [JsonProperty("address_2")]
        public string Address2 { get; set; }

        /// <summary>
        /// Zip code.
        /// </summary>
        [JsonProperty("zip")]
        public string Zip { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// State.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Country id.
        /// </summary>
        [JsonProperty("country_id")]
        public string CountryId { get; set; }

        /// <summary>
        /// Country.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Billing per robot.
        /// </summary>
        [JsonProperty("robots")]
        public Dictionary<string, RobotBilling> Robots { get; set; }

        /// <summary>
        /// Subtotal.
        /// </summary>
        [JsonProperty("sub_total")]
        public decimal SubTotal { get; set; }

        /// <summary>
        /// Whether billing is prorated.
        /// </summary>
        [JsonProperty("is_prorated")]
        public bool IsProrated { get; set; }

        /// <summary>
        /// Used gigabytes.
        /// </summary>
        [JsonProperty("used_gb")]
        public decimal UsedGb { get; set; }

        /// <summary>
        /// Additional gigabytes.
        /// </summary>
        [JsonProperty("additional_gb")]
        public decimal AdditionalGb { get; set; }

        /// <summary>
        /// Additional gigabytes fee.
        /// </summary>
        [JsonProperty("additional_gb_fee")]
        public decimal AdditionalGbFee { get; set; }

        /// <summary>
        /// Final subtotal.
        /// </summary>
        [JsonProperty("final_sub_total")]
        public decimal FinalSubTotal { get; set; }

        /// <summary>
        /// Reward discount percent.
        /// </summary>
        [JsonProperty("reward_discount_percent")]
        public decimal RewardDiscountPercent { get; set; }

        /// <summary>
        /// Reward discount.
        /// </summary>
        [JsonProperty("reward_discount")]
        public decimal RewardDiscount { get; set; }

        /// <summary>
        /// Coupon discount percent.
        /// </summary>
        [JsonProperty("coupon_discount_percent")]
        public decimal CouponDiscountPercent { get; set; }

        /// <summary>
        /// Coupon discount.
        /// </summary>
        [JsonProperty("coupon_discount")]
        public decimal CouponDiscount { get; set; }

        /// <summary>
        /// Signup discount percent.
        /// </summary>
        [JsonProperty("signup_discount_percent")]
        public decimal SignupDiscountPercent { get; set; }

        /// <summary>
        /// Signup discount.
        /// </summary>
        [JsonProperty("signup_discount")]
        public decimal SignupDiscount { get; set; }

        /// <summary>
        /// Credit.
        /// </summary>
        [JsonProperty("credit")]
        public decimal Credit { get; set; }

        /// <summary>
        /// Billing limit which cannot be exceeded.
        /// </summary>
        [JsonProperty("bill_limit")]
        public decimal BillLimit { get; set; }

        /// <summary>
        /// VAT rate percentage.
        /// </summary>
        [JsonProperty("vat_rate")]
        public decimal VatRate { get; set; }

        /// <summary>
        /// VAT.
        /// </summary>
        [JsonProperty("vat")]
        public decimal Vat { get; set; }

        /// <summary>
        /// Whether reverse charge VAT applied.
        /// </summary>
        [JsonProperty("reverse_charge_vat")]
        public bool ReverseChargeVat { get; set; }

        /// <summary>
        /// VAT id.
        /// </summary>
        [JsonProperty("vat_id")]
        public string VatId { get; set; }

        /// <summary>
        /// Total.
        /// </summary>
        [JsonProperty("total")]
        public decimal Total { get; set; }
    }
}
