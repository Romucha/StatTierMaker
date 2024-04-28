using StatTierMaker.Db.DTO.Requests.Entities;
using StatTierMaker.Db.DTO.Requests.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestDbData.Entities.Update
{
    public static class SingularUpdateTierEntitiyRequests
    {
        public static UpdateTierEntityRequest Normal(int id, int tierId)
        {
            return new()
            {
                Id = id,
                Name = "Updated Entity Name",
                Description = "Updated Entity Description",
                TierId = tierId,
                TierEntityParameters = new[]
                {
                    new UpdateTierParameterRequest()
                    {
                        Id = 1,
                        Name = "Updated Tier Parameter Name 1",
                        Description = " Updated Tier Parameter Description 1",
                        Coefficient = 1,
                        Value = API.Tiers.TierValue.F,
                        TierEntityId = id
                    },
                    new UpdateTierParameterRequest()
                    {
                        Id = 1,
                        Name = "Updated Tier Parameter Name 2",
                        Description = " Updated Tier Parameter Description 2",
                        Coefficient = 2,
                        Value = API.Tiers.TierValue.E,
                        TierEntityId = id
                    },
                    new UpdateTierParameterRequest()
                    {
                        Id = 1,
                        Name = "Updated Tier Parameter Name 3",
                        Description = " Updated Tier Parameter Description 3",
                        Coefficient = 3,
                        Value = API.Tiers.TierValue.D,
                        TierEntityId = id
                    }
                }
            };
        }

        public static UpdateTierEntityRequest Invalid()
        {
            return new()
            {
                Id = -1,
                Name = "",
                Description = "",
                TierEntityParameters = Array.Empty<UpdateTierParameterRequest>(),
                TierId = 0,
            };
        }

        public static UpdateTierEntityRequest Default()
        {
            return new();
        }

        public static UpdateTierEntityRequest? Null()
        {
            return null;
        }
    }
}
