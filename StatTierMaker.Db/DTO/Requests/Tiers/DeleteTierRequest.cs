using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Requests.Tiers
{
    public record DeleteTierRequest
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
