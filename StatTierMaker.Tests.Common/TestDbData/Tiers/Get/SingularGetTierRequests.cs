using StatTierMaker.Db.DTO.Requests.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestDbData.Tiers.Get
{
    public static class SingularGetTierRequests
    {
        public static GetTierRequest Normal(int id = 1)
        {
            return new GetTierRequest()
            {
                Id = id,
            };
        }

        public static GetTierRequest Invalid()
        {
            return new GetTierRequest()
            {
                Id = -1,
            };
        }

        public static GetTierRequest Default()
        {
            return new();
        }

        public static GetTierRequest? Null()
        {
            return null;
        }
    }
}
