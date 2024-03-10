using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.TierTemplates
{
    /// <summary>
    /// Template of a tier list.
    /// </summary>
    public class TierListTemplate
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Template of tier list entity.
        /// </summary>
        public TierEntityTemplate? TierEntityTemplate { get; set; }
    }
}
