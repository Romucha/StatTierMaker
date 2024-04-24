using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Requests.Parameters
{
    public record AddTierParameterRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int TierEntityId { get; set; }
    }
}
