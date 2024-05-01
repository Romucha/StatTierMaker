using StatTierMaker.API.Attributes;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.DTO.Requests.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Requests.Tiers
{
    public record AddTierRequest
    {
        [Required]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }

        public TierValue Value { get; set; }

        [CollectionNotEmpty]
        public ICollection<AddTierEntityRequest> Entities { get; set; }

        [Range(1, int.MaxValue)]
        public int TierListId { get; set; }
    }
}
