using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestData.Parameters
{
    public static class SingularParameters
    {
        public static TierParameter Normal()
        {
            return new TierParameter()
            {
                Name = "Name",
                Description = "Description",
                Value = TierValue.B,
                Coefficient = 1,
            };
        }

        public static TierParameter Invalid() 
        {
            return new TierParameter()
            {
                Name = "Name",
                Description = "Description",
                Value = TierValue.B,
                Coefficient = 0,
            };
        }

        public static TierParameter Default()
        {
            return new TierParameter();
        }

        public static TierParameter? Null()
        {
            return null;
        }
    }
}
