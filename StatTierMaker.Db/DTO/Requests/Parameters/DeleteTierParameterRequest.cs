using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Requests.Parameters
{
    public record DeleteTierParameterRequest
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
