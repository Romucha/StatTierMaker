﻿using StatTierMaker.Db.DTO.Responses.Entities;
using StatTierMaker.Db.DTO.Responses.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Responses.Lists
{
    public record UpdateTierListResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<UpdateTierListResponse> Tiers { get; set; }

        public ICollection<UpdateTierEntityResponse> Entities { get; set; }
    }
}
