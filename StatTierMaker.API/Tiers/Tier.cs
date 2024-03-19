using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tiers
{
    /// <summary>
    /// Tier object.
    /// </summary>
    public class Tier
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of tier.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Description of a tier.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Value of this tier.
        /// </summary>
        public TierValue TierValue { get; set; }
    }
}
