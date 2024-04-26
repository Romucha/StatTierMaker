using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestAPIData.Tiers
{
    public static class SingularTiers
    {
        public static Tier Normal()
        {
            return new Tier()
            {
                Name = "Tier name",
                Description = "Tier description",
                Entities = new List<TierEntity>(),
                Value = TierValue.A
            };
        }

        public static Tier Invalid()
        {
            return new Tier()
            {
                Name = "",
                Description = "Tier description",
                Entities = null,
                Value = TierValue.A
            };
        }

        public static Tier Default()
        {
            return new Tier();
        }

        public static Tier? Null()
        {
            return null;
        }
    }
}
