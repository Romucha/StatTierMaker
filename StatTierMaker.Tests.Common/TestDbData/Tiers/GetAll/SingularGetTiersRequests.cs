using StatTierMaker.Db.DTO.Requests.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestDbData.Tiers.GetAll
{
    public static class SingularGetTiersRequests
    {
        public static GetTiersRequest Normal()
        {
            return new GetTiersRequest()
            {
                PageNumber = 1,
                PageSize = 1,
            };
        }

        public static GetTiersRequest Invalid()
        {
            return new GetTiersRequest()
            {
                PageNumber = -1,
                PageSize = -1,
            };
        }

        public static GetTiersRequest Default()
        {
            return new();
        }

        public static GetTiersRequest? Null()
        {
            return null;
        }
    }
}
