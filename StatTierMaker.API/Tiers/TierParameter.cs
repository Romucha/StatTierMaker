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
    /// A parameter of a tier entity.
    /// </summary>
    public class TierParameter
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
        /// Value of parameter.
        /// </summary>
        [Required]
        public TierValue Value { get; set; }

        /// <summary>
        /// Coefficient of parameter.
        /// </summary>
        [Range(0, double.MaxValue, MinimumIsExclusive = true)]
        public double Coefficient { get; set; } = 1;

        /// <summary>
        /// Id of a linked tier entity.
        /// </summary>
        public int TierEntityId { get; set; }

        /// <summary>
        /// Linked tier entity.
        /// </summary>
        public TierEntity? TierEntity { get; set; }
    }
}
