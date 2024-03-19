using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.TierTemplates
{
    /// <summary>
    /// Template of a tier entity parameter.
    /// </summary>
    public class TierParameterTemplate
    {
        /// <summary>
        /// Name of parameter.
        /// </summary>
        [Required]
        public string? Name { get; set; }

        /// <summary>
        /// Description of parameter.
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        public string? Description { get; set; }

        /// <summary>
        /// Coefficient of parameter.
        /// </summary>
        [Range(0, double.MaxValue, MinimumIsExclusive = true)]
        public double Coefficient { get; set; } = 1;
    }
}
