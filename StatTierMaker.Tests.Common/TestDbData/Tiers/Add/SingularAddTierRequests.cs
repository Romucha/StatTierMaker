using StatTierMaker.Db.DTO.Requests.Tiers;
using StatTierMaker.Tests.Common.TestDbData.Entities.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestDbData.Tiers.Add
{
    public static class SingularAddTierRequests
    {
        public static AddTierRequest Normal(int tierListId = 1)
        {
            return new()
            {
                Name = "Tier Name",
                Description = "Tier Description",
                Entities = new[]
                {
                    SingularAddTierEntityRequests.Normal()
                },
                TierListId = tierListId,
                Value = API.Tiers.TierValue.B
            };
        }

        public static AddTierRequest Invalid()
        {
            return new()
            {
                Name = "",
                Description = null,
                Entities = null,
                TierListId = -1,
                Value = API.Tiers.TierValue.F
            };
        }

        public static AddTierRequest Default() 
        {
            return new() { };
        }

        public static AddTierRequest? Null()
        {
            return null;
        }
    }
}
