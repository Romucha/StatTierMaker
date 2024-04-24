using StatTierMaker.API.Tiers;
using StatTierMaker.Db.DTO.Requests.Entities;
using StatTierMaker.Db.DTO.Responses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Responses.Tiers
{
    public record GetTierResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TierValue Value { get; set; }

        public ICollection<GetTierEntityResponse> Entities { get; set; }

        public int TierListId { get; set; }
    }
}
