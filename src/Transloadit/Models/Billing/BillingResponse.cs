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
        public string InvoiceId { get; set; }

        /// <summary>
        /// Account name.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Account email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Billing month.
        /// </summary>
        public string Month { get; set; }

        /// <summary>
        /// Invoice creation date.
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Billing plan.
        /// </summary>
        public BillingPlan Plan { get; set; }

        /// <summary>
        /// Currency.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Company name.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Contact email address.
        /// </summary>
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
        public string Zip { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Country id.
        /// </summary>
        public string CountryId { get; set; }

        /// <summary>
        /// Country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Billing per robot.
        /// </summary>
        public Dictionary<string, RobotBilling> Robots { get; set; }

        /// <summary>
        /// Subtotal.
        /// </summary>
        public decimal SubTotal { get; set; }

        /// <summary>
        /// Whether billing is prorated.
        /// </summary>
        public bool IsProrated { get; set; }

        /// <summary>
        /// Used gigabytes.
        /// </summary>
        public decimal UsedGb { get; set; }

        /// <summary>
        /// Additional gigabytes.
        /// </summary>
        public decimal AdditionalGb { get; set; }

        /// <summary>
        /// Additional gigabytes fee.
        /// </summary>
        public decimal AdditionalGbFee { get; set; }

        /// <summary>
        /// Final subtotal.
        /// </summary>
        public decimal FinalSubTotal { get; set; }

        /// <summary>
        /// Reward discount percent.
        /// </summary>
        public decimal RewardDiscountPercent { get; set; }

        /// <summary>
        /// Reward discount.
        /// </summary>
        public decimal RewardDiscount { get; set; }

        /// <summary>
        /// Coupon discount percent.
        /// </summary>
        public decimal CouponDiscountPercent { get; set; }

        /// <summary>
        /// Coupon discount.
        /// </summary>
        public decimal CouponDiscount { get; set; }

        /// <summary>
        /// Signup discount percent.
        /// </summary>
        public decimal SignupDiscountPercent { get; set; }

        /// <summary>
        /// Signup discount.
        /// </summary>
        public decimal SignupDiscount { get; set; }

        /// <summary>
        /// Credit.
        /// </summary>
        public decimal Credit { get; set; }

        /// <summary>
        /// Billing limit which cannot be exceeded.
        /// </summary>
        public decimal BillLimit { get; set; }

        /// <summary>
        /// VAT rate percentage.
        /// </summary>
        public decimal VatRate { get; set; }

        /// <summary>
        /// VAT.
        /// </summary>
        public decimal Vat { get; set; }

        /// <summary>
        /// Whether reverse charge VAT applied.
        /// </summary>
        public bool ReverseChargeVat { get; set; }

        /// <summary>
        /// VAT id.
        /// </summary>
        public string VatId { get; set; }

        /// <summary>
        /// Total.
        /// </summary>
        public decimal Total { get; set; }
    }
}
