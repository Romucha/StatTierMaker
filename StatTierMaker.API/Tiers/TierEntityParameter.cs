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
    public class TierEntityParameter
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of a parameter.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Value of parameter.
        /// </summary>
        public TierValues Value { get; set; }

        /// <summary>
        /// Coefficient of a parameter.
        /// </summary>
        public double Coefficient { get; set; } = 1;
    }
}
