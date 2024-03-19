using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string? Name { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string? Description { get; set; }
    }
}
