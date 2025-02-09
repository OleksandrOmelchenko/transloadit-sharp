using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models.Billing
{
    public class RobotBilling
    {
        [JsonProperty("rawGb")]
        public decimal RawGb { get; set; }

        public decimal Gb { get; set; }

        [JsonProperty("freeGb")]
        public decimal FreeGb { get; set; }

        [JsonProperty("discountedGb")]
        public decimal DiscountedGb { get; set; }

        [JsonProperty("gbFactorApplied")]
        public decimal GbFactorApplied { get; set; }

        public decimal Factor { get; set; }

        public List<RobotBillingByRegionAndFactor> ByRegionAndFactor { get; set; }
    }

    public class RobotBillingByRegionAndFactor
    {
        public decimal Factor { get; set; }

        [JsonProperty("rawGb")]
        public decimal RawGb { get; set; }

        [JsonProperty("gbFactorApplied")]
        public decimal GbFactorApplied { get; set; }

        [JsonProperty("freeGb")]
        public decimal FreeGb { get; set; }

        public string Region { get; set; }
    }
}
