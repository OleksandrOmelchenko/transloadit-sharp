using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

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
        [TransloaditJsonName("rawGb")]
        public decimal RawGb { get; set; }

        /// <summary>
        /// Gigabytes.
        /// </summary>
        [TransloaditJsonName("gb")]
        public decimal Gb { get; set; }

        /// <summary>
        /// Free gigabytes.
        /// </summary>
        [TransloaditJsonName("freeGb")]
        public decimal FreeGb { get; set; }

        /// <summary>
        /// Discounted gigabytes.
        /// </summary>
        [TransloaditJsonName("discountedGb")]
        public decimal DiscountedGb { get; set; }

        /// <summary>
        /// Gigabytes factor applied.
        /// </summary>
        [TransloaditJsonName("gbFactorApplied")]
        public decimal GbFactorApplied { get; set; }

        /// <summary>
        /// Factor.
        /// </summary>
        [TransloaditJsonName("factor")]
        public decimal Factor { get; set; }

        /// <summary>
        /// Grouping by region and factor.
        /// </summary>
        [TransloaditJsonName("by_region_and_factor")]
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
        [TransloaditJsonName("factor")]
        public decimal Factor { get; set; }

        /// <summary>
        /// Raw gigabytes.
        /// </summary>
        [TransloaditJsonName("rawGb")]
        public decimal RawGb { get; set; }

        /// <summary>
        /// Gigabytes factor applied.
        /// </summary>
        [TransloaditJsonName("gbFactorApplied")]
        public decimal GbFactorApplied { get; set; }

        /// <summary>
        /// Free gigabytes.
        /// </summary>
        [TransloaditJsonName("freeGb")]
        public decimal FreeGb { get; set; }

        /// <summary>
        /// AWS Region.
        /// </summary>
        [TransloaditJsonName("region")]
        public string Region { get; set; }
    }
}
