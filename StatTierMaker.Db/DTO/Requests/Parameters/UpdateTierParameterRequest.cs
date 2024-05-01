using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Requests.Parameters
{
    public record UpdateTierParameterRequest
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }

        public TierValue Value { get; set; }

        [Range(0, double.MaxValue)]
        public double Coefficient { get; set; }

        [Range(1, int.MaxValue)]
        public int TierEntityId { get; set; }
    }
}
