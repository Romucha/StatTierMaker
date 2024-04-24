using StatTierMaker.Db.DTO.Requests.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Requests.Entities
{
    public record AddTierEntityRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int TierId { get; set; }

        public ICollection<AddTierParameterRequest> Parameters { get; set; }
    }
}
