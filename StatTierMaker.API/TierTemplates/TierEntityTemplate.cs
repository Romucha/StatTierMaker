using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.TierTemplates
{
    public class TierEntityTemplate
    {
        /// <summary>
        /// List of entity parameter templates.
        /// </summary>
        public ICollection<TierParameterTemplate>? TierParameterTemplates { get; set; }
    }
}
