using System.Collections.Generic;
using Newtonsoft.Json;

namespace Transloadit.Models.Billing
{
    /// <summary>
    /// Represents billing for the Robot.
    /// </summary>
    public class RobotBilling
    {
        /// <summary>
        /// Raw gigabytes.
        /// </summary>
        [JsonProperty("rawGb")]
        public decimal RawGb { get; set; }

        /// <summary>
        /// Gigabytes.
        /// </summary>
        [JsonProperty("gb")]
        public decimal Gb { get; set; }

        /// <summary>
        /// Free gigabytes.
        /// </summary>
        [JsonProperty("freeGb")]
        public decimal FreeGb { get; set; }

        /// <summary>
        /// Discounted gigabytes.
        /// </summary>
        [JsonProperty("discountedGb")]
        public decimal DiscountedGb { get; set; }

        /// <summary>
        /// Gigabytes factor applied.
        /// </summary>
        [JsonProperty("gbFactorApplied")]
        public decimal GbFactorApplied { get; set; }

        /// <summary>
        /// Factor.
        /// </summary>
        [JsonProperty("factor")]
        public decimal Factor { get; set; }

        /// <summary>
        /// Grouping by region and factor.
        /// </summary>
        [JsonProperty("by_region_and_factor")]
        public List<RobotBillingByRegionAndFactor> ByRegionAndFactor { get; set; }
    }

    /// <summary>
    /// Represents Robot billing grouped by region and factor.
    /// </summary>
    public class RobotBillingByRegionAndFactor
    {
        /// <summary>
        /// Factor.
        /// </summary>
        [JsonProperty("factor")]
        public decimal Factor { get; set; }

        /// <summary>
        /// Raw gigabytes.
        /// </summary>
        [JsonProperty("rawGb")]
        public decimal RawGb { get; set; }

        /// <summary>
        /// Gigabytes factor applied.
        /// </summary>
        [JsonProperty("gbFactorApplied")]
        public decimal GbFactorApplied { get; set; }

        /// <summary>
        /// Free gigabytes.
        /// </summary>
        [JsonProperty("freeGb")]
        public decimal FreeGb { get; set; }

        /// <summary>
        /// AWS Region.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }
    }
}
