﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Responses.Entities
{
    public record GetTierEntitiesResponses
    {
        public IEnumerable<GetTierEntitiesResponse> Entities { get; set; }
    }
}
