using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models.Billing
{
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
}
