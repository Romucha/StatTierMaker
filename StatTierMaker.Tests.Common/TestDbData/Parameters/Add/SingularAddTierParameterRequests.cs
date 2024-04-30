using StatTierMaker.Db.DTO.Requests.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestDbData.Parameters.Add
{
    public static class SingularAddTierParameterRequests
    {
        public static AddTierParameterRequest Normal(int tierEntityId = 1)
        {
            return new AddTierParameterRequest()
            {
                Name = "Tier Parameter Name",
                Description = "Tier Parameter Description",
                TierEntityId = tierEntityId
            };
        }

        public static AddTierParameterRequest Invalid()
        {
            return new AddTierParameterRequest()
            {
                Name = "",
                Description = "",
                TierEntityId = -1
            };
        }

        public static AddTierParameterRequest Default()
        {
            return new();
        }

        public static AddTierParameterRequest? Null()
        {
            return null;
        }
    }
}
