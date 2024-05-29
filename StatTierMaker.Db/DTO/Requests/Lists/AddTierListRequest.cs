using StatTierMaker.API.Attributes;
using StatTierMaker.Db.DTO.Requests.Entities;
using StatTierMaker.Db.DTO.Requests.Tiers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Requests.Lists
{
    public record AddTierListRequest
    {
        [Required]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }

        [Required]
        public ICollection<AddTierRequest> Tiers { get; set; }

        [Required]
        public ICollection<AddTierEntityRequest> Entities { get; set; }
    }
}
