using System;
using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Billing;

/// <summary>
/// Represents billing data.
/// </summary>
public class BillingResponse : ResponseBase
{
    /// <summary>
    /// Invoice id.
    /// </summary>
    [TransloaditJsonName("invoice_id")]
    public string InvoiceId { get; set; }

    /// <summary>
    /// Account name.
    /// </summary>
    [TransloaditJsonName("to")]
    public string To { get; set; }

    /// <summary>
    /// Account email.
    /// </summary>
    [TransloaditJsonName("email")]
    public string Email { get; set; }

    /// <summary>
    /// Billing month.
    /// </summary>
    [TransloaditJsonName("month")]
    public string Month { get; set; }

    /// <summary>
    /// Invoice creation date.
    /// </summary>
    [TransloaditJsonName("created")]
    public DateTimeOffset Created { get; set; }

    /// <summary>
    /// Billing plan.
    /// </summary>
    [TransloaditJsonName("plan")]
    public BillingPlan Plan { get; set; }

    /// <summary>
    /// Currency.
    /// </summary>
    [TransloaditJsonName("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Company name.
    /// </summary>
    [TransloaditJsonName("company")]
    public string Company { get; set; }

    /// <summary>
    /// Contact email address.
    /// </summary>
    [TransloaditJsonName("to_contact_email_address")]
    public string ToContactEmailAddress { get; set; }

    /// <summary>
    /// Address line 1.
    /// </summary>
    [TransloaditJsonName("address_1")]
    public string Address1 { get; set; }

    /// <summary>
    /// Address line 2.
    /// </summary>
    [TransloaditJsonName("address_2")]
    public string Address2 { get; set; }

    /// <summary>
    /// Zip code.
    /// </summary>
    [TransloaditJsonName("zip")]
    public string Zip { get; set; }

    /// <summary>
    /// City.
    /// </summary>
    [TransloaditJsonName("city")]
    public string City { get; set; }

    /// <summary>
    /// State.
    /// </summary>
    [TransloaditJsonName("state")]
    public string State { get; set; }

    /// <summary>
    /// Country id.
    /// </summary>
    [TransloaditJsonName("country_id")]
    public string CountryId { get; set; }

    /// <summary>
    /// Country.
    /// </summary>
    [TransloaditJsonName("country")]
    public string Country { get; set; }

    /// <summary>
    /// Billing per robot.
    /// </summary>
    [TransloaditJsonName("robots")]
    public Dictionary<string, RobotBilling> Robots { get; set; }

    /// <summary>
    /// Subtotal.
    /// </summary>
    [TransloaditJsonName("sub_total")]
    public decimal SubTotal { get; set; }

    /// <summary>
    /// Whether billing is prorated.
    /// </summary>
    [TransloaditJsonName("is_prorated")]
    public bool IsProrated { get; set; }

    /// <summary>
    /// Used gigabytes.
    /// </summary>
    [TransloaditJsonName("used_gb")]
    public decimal UsedGb { get; set; }

    /// <summary>
    /// Additional gigabytes.
    /// </summary>
    [TransloaditJsonName("additional_gb")]
    public decimal AdditionalGb { get; set; }

    /// <summary>
    /// Additional gigabytes fee.
    /// </summary>
    [TransloaditJsonName("additional_gb_fee")]
    public decimal AdditionalGbFee { get; set; }

    /// <summary>
    /// Final subtotal.
    /// </summary>
    [TransloaditJsonName("final_sub_total")]
    public decimal FinalSubTotal { get; set; }

    /// <summary>
    /// Reward discount percent.
    /// </summary>
    [TransloaditJsonName("reward_discount_percent")]
    public decimal RewardDiscountPercent { get; set; }

    /// <summary>
    /// Reward discount.
    /// </summary>
    [TransloaditJsonName("reward_discount")]
    public decimal RewardDiscount { get; set; }

    /// <summary>
    /// Coupon discount percent.
    /// </summary>
    [TransloaditJsonName("coupon_discount_percent")]
    public decimal CouponDiscountPercent { get; set; }

    /// <summary>
    /// Coupon discount.
    /// </summary>
    [TransloaditJsonName("coupon_discount")]
    public decimal CouponDiscount { get; set; }

    /// <summary>
    /// Signup discount percent.
    /// </summary>
    [TransloaditJsonName("signup_discount_percent")]
    public decimal SignupDiscountPercent { get; set; }

    /// <summary>
    /// Signup discount.
    /// </summary>
    [TransloaditJsonName("signup_discount")]
    public decimal SignupDiscount { get; set; }

    /// <summary>
    /// Credit.
    /// </summary>
    [TransloaditJsonName("credit")]
    public decimal Credit { get; set; }

    /// <summary>
    /// Billing limit which cannot be exceeded.
    /// </summary>
    [TransloaditJsonName("bill_limit")]
    public decimal BillLimit { get; set; }

    /// <summary>
    /// VAT rate percentage.
    /// </summary>
    [TransloaditJsonName("vat_rate")]
    public decimal VatRate { get; set; }

    /// <summary>
    /// VAT.
    /// </summary>
    [TransloaditJsonName("vat")]
    public decimal Vat { get; set; }

    /// <summary>
    /// Whether reverse charge VAT applied.
    /// </summary>
    [TransloaditJsonName("reverse_charge_vat")]
    public bool ReverseChargeVat { get; set; }

    /// <summary>
    /// VAT id.
    /// </summary>
    [TransloaditJsonName("vat_id")]
    public string VatId { get; set; }

    /// <summary>
    /// Total.
    /// </summary>
    [TransloaditJsonName("total")]
    public decimal Total { get; set; }
}
