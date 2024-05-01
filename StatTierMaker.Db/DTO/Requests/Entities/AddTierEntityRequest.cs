using StatTierMaker.API.Attributes;
using StatTierMaker.Db.DTO.Requests.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Requests.Entities
{
    public record AddTierEntityRequest
    {
        [Required]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }

        [Range(1, int.MaxValue)]
        public int TierId { get; set; }

        [CollectionNotEmpty]
        public ICollection<AddTierParameterRequest> TierEntityParameters { get; set; }
    }
}
