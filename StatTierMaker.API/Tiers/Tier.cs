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
    /// Tier object.
    /// </summary>
    public class Tier
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public TierValue Value { get; set; }

        /// <summary>
        /// Collection of tier entities that belong to this tier.
        /// </summary>
        public ICollection<TierEntity>? Entities { get; set; }

        /// <summary>
        /// Id of a linked tier list.
        /// </summary>
        [ForeignKey(nameof(TierList))]
        public int TierListId { get; set; }

        /// <summary>
        /// Linked tier list.
        /// </summary>
        public TierList? TierList { get; set; }
    }
}
