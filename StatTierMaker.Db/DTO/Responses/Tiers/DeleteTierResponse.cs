using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Responses.Tiers
{
    public record DeleteTierResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
