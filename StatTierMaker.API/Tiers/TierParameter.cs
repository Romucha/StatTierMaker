using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tiers
{
    /// <summary>
    /// A parameter of a tier entity.
    /// </summary>
    public class TierParameter
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of parameter.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Description of parameter.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Value of parameter.
        /// </summary>
        public TierValue Value { get; set; }

        /// <summary>
        /// Coefficient of parameter.
        /// </summary>
        public double Coefficient { get; set; } = 1;
    }
}
