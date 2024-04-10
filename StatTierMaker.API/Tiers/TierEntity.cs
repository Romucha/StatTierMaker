using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tiers
{
    /// <summary>
    /// Entity of a tier list.
    /// </summary>
    public class TierEntity
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name of a tier entity.
        /// </summary>
        [Required]
        public string? Name { get; set; }

        /// <summary>
        /// Description of a tier entity.
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        public string? Description { get; set; }

        /// <summary>
        /// Id of a linked tier.
        /// </summary>
        [ForeignKey(nameof(Tier))]
        public int TierId { get; set; }

        /// <summary>
        /// A tier that this entity belongs to.
        /// </summary>
        public Tier? Tier { get; set; }

        /// <summary>
        /// List of entity parameters.
        /// </summary>
        [Required]
        public ICollection<TierParameter>? TierEntityParameters  { get; set; }
    }
}
