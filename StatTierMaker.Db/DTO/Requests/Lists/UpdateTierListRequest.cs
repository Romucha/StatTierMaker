using StatTierMaker.Db.DTO.Requests.Entities;
using StatTierMaker.Db.DTO.Requests.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Requests.Lists
{
    public record UpdateTierListRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<UpdateTierRequest> Tiers { get; set; }

        public ICollection<UpdateTierEntityRequest> Entities { get; set; }
    }
}
