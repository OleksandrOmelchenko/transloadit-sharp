using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [JsonProperty("price_per_month")]
        public int PricePerMonth { get; set; }

        [JsonProperty("gb_included")]
        public int GbIncluded { get; set; }

        [JsonProperty("price_per_gb")]
        public double PricePerGb { get; set; }

        [JsonProperty("gb_limit")]
        public object GbLimit { get; set; }

        [JsonProperty("has_lifetime_limit")]
        public bool HasLifetimeLimit { get; set; }
    }

    public class BillingReponse
    {
        [JsonProperty("ok")]
        public string Ok { get; set; }

        [JsonProperty("invoice_id")]
        public string InvoiceId { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("month")]
        public string Month { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("plan")]
        public Plan Plan { get; set; }

        [JsonProperty("used_gb")]
        public double UsedGb { get; set; }

        [JsonProperty("additional_gb")]
        public int AdditionalGb { get; set; }

        [JsonProperty("additional_gb_fee")]
        public int AdditionalGbFee { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("address_1")]
        public string Address1 { get; set; }

        [JsonProperty("address_2")]
        public string Address2 { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public object State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("robots")]
        public Dictionary<string, RobotBilling> Robots { get; set; }

        [JsonProperty("sub_total")]
        public int SubTotal { get; set; }

        [JsonProperty("reward_discount_percent")]
        public int RewardDiscountPercent { get; set; }

        [JsonProperty("reward_discount")]
        public double RewardDiscount { get; set; }

        [JsonProperty("signup_discount_percent")]
        public int SignupDiscountPercent { get; set; }

        [JsonProperty("signup_discount")]
        public int SignupDiscount { get; set; }

        [JsonProperty("credit")]
        public int Credit { get; set; }

        [JsonProperty("bill_limit")]
        public int BillLimit { get; set; }

        [JsonProperty("vat_rate")]
        public double VatRate { get; set; }

        [JsonProperty("vat")]
        public double Vat { get; set; }

        [JsonProperty("vat_id")]
        public string VatId { get; set; }

        [JsonProperty("reverse_charge_vat")]
        public bool ReverseChargeVat { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }
    }
}
