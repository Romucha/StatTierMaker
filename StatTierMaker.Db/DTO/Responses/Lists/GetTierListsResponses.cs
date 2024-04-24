using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.DTO.Responses.Lists
{
    public record GetTierListsResponses
    {
        public IEnumerable<GetTierListsResponse> TierLists { get; set; }
    }
}
