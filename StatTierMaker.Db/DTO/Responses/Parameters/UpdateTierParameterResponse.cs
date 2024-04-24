using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Responses.Parameters
{
    public record UpdateTierParameterResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TierValue Value { get; set; }

        public double Coefficient { get; set; }

        public int TierEntityId { get; set; }
    }
}
