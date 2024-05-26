using StatTierMaker.Db.DTO.Requests.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestDbData.Parameters.Update
{
    public static class SingularUpdateTierParameterRequests
    {
        public static UpdateTierParameterRequest Normal(int id = 1, int entityId = 1)
        {
            return new UpdateTierParameterRequest
            {
                Id = id,
                Name = "Updated Tier Parameter Name",
                Description = "Updated Tier Parameter Description",
                Coefficient = 10,
                Value = API.Tiers.TierValue.S,
                TierEntityId = entityId
            };
        }

        public static UpdateTierParameterRequest Invalid()
        {
            return new()
            {
                Name = null,
                Description = null,
                Coefficient = -1,
                Value = API.Tiers.TierValue.S
            };
        }

        public static UpdateTierParameterRequest Default()
        {
            return new();
        }

        public static UpdateTierParameterRequest? Null()
        {
            return null;
        }
    }
}
