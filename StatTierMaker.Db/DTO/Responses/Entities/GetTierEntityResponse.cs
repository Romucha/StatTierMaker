using StatTierMaker.API.Tiers;
using StatTierMaker.Db.DTO.Responses.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Responses.Entities
{
    public record GetTierEntityResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TierId { get; set; }

        public ICollection<GetTierParameterResponse>? TierEntityParameters { get; set; }
    }
}
