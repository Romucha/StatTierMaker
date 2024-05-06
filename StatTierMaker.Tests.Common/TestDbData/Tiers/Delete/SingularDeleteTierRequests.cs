using StatTierMaker.Db.DTO.Requests.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestDbData.Tiers.Delete
{
    public static class SingularDeleteTierRequests
    {
        public static DeleteTierRequest Normal(int id = 1)
        {
            return new DeleteTierRequest()
            {
                Id = id
            };
        }

        public static DeleteTierRequest Invalid()
        {
            return new DeleteTierRequest()
            {
                Id = -1
            };
        }

        public static DeleteTierRequest Default()
        {
            return new DeleteTierRequest();
        }

        public static DeleteTierRequest? Null()
        {
            return null;
        }
    }
}
