using StatTierMaker.Db.DTO.Requests.Entities;
using StatTierMaker.Db.DTO.Requests.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestDbData.Entities.Add
{
    public static class SingularAddEntityRequests
    {
        public static AddTierEntityRequest Normal()
        {
            return new AddTierEntityRequest()
            {
                Name = "Tier Entity Name",
                Description = "Tier Entity Description",
                TierEntityParameters = new List<AddTierParameterRequest>()
                {
                    new AddTierParameterRequest
                    {
                        Name = "Tier Parameter Name 1",
                        Description = "Tier Parameter Description 1"
                    },
                    new AddTierParameterRequest
                    {
                        Name = "Tier Parameter Name 2",
                        Description = "Tier Parameter Description 2"
                    },
                    new AddTierParameterRequest
                    {
                        Name = "Tier Parameter Name 3",
                        Description = "Tier Parameter Description 3"
                    }
                }
            };
        }

        public static AddTierEntityRequest Invalid()
        {
            return new AddTierEntityRequest
            {
                Name = "",
                Description = null,
                TierEntityParameters = null
            };
        }

        public static AddTierEntityRequest Default()
        {
            return new();
        }

        public static AddTierEntityRequest? Null()
        {
            return null;
        }
    }
}
