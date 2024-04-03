using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tests.TestData.Entities
{
    internal static class SingularEntities
    {
        public static TierEntity Normal()
        {
            return new TierEntity()
            {
                Name = "Entity",
                Description = "Description",
                TierEntityParameters = new List<TierParameter>
                {
                    new TierParameter()
                    {
                        Name = "Parameter 1",
                        Description = "Description",
                        Value = TierValue.A,
                        Coefficient = 1
                    },
                    new TierParameter()
                    {
                        Name = "Parameter 2",
                        Description = "Description",
                        Value = TierValue.B,
                        Coefficient = 1
                    },
                    new TierParameter()
                    {
                        Name = "Parameter 3",
                        Description = "Description",
                        Value = TierValue.C,
                        Coefficient = 1
                    }
                }
            };
        }

        public static TierEntity Invalid()
        {
            return new TierEntity()
            {
                Name = null
            };
        }

        public static TierEntity Default()
        {
            return new TierEntity();
        }

        public static TierEntity? Null()
        {
            return null;
        }
    }
}
