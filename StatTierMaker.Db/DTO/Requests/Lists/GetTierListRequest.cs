using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Requests.Lists
{
    public record GetTierListRequest
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
