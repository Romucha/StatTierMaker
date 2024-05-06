using StatTierMaker.Db.DTO.Requests.Entities;
using StatTierMaker.Db.DTO.Requests.Tiers;
using StatTierMaker.Tests.Common.TestDbData.Entities.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestDbData.Tiers.Update
{
    public static class SingularUpdateTierRequests
    {
        public static UpdateTierRequest Normal(int id = 1, int tierListId = 1)
        {
            return new UpdateTierRequest()
            {
                Id = id,
                Name = "Updated Tier Name",
                Description = "Updated Tier Description",
                Entities = new[]
                {
                    SingularUpdateTierEntitiyRequests.Normal(1, id)
                },
                TierListId = tierListId,
                Value = API.Tiers.TierValue.F
            };
        }

        public static UpdateTierRequest Invalid()
        {
            return new UpdateTierRequest()
            {
                Id = -1,
                Name = "",
                Description = null,
                Entities = null,
                TierListId = -1,
                Value = API.Tiers.TierValue.F
            };
        }

        public static UpdateTierRequest Default()
        {
            return new();
        }

        public static UpdateTierRequest? Null()
        {
            return null;
        }
    }
}
