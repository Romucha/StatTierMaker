﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Responses.Tiers
{
    public record GetTiersResponses
    {
        public IEnumerable<GetTiersResponse> Tiers {  get; set; }
    }
}
