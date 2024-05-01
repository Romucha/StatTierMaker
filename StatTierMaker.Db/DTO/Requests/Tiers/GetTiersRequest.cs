using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Requests.Tiers
{
    public record GetTiersRequest
    {
        [Range(0, int.MaxValue)]
        public int PageSize { get; set; }

        [Range(0, int.MaxValue)]
        public int PageNumber { get; set; }
    }
}
