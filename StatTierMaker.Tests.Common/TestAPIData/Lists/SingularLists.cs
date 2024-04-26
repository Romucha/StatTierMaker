using StatTierMaker.API.Tiers;
using StatTierMaker.Tests.Common.TestAPIData.Entities;
using StatTierMaker.Tests.Common.TestAPIData.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestAPIData.Lists
{
    public static class SingularLists
    {
        public static TierList Normal()
        {
            return new TierList()
            {
                Name = "Test name",
                Description = "Test description",
                Entities = EntityCollections.Normal().ToList(),
                Tiers = TierCollections.Normal().ToList(),
            };
        }


        public static TierList Invalid()
        {
            return new TierList()
            {
                Name = "",
                Description = "Test description",
                Entities = EntityCollections.WithInvalidElements().ToList(),
                Tiers = TierCollections.WithInvalidElements().ToList(),
            };
        }

        public static TierList Default()
        {
            return new TierList();
        }

        public static TierList? Null()
        {
            return null;
        }

        public static TierList WithEmptyTiers()
        {
            return new TierList()
            {
                Name = "Test name",
                Description = "Test description",
                Tiers = TierCollections.Empty().ToList(),
                Entities = EntityCollections.Normal().ToList()
            };
        }


        public static TierList WithNullTiers()
        {
            return new TierList()
            {
                Name = "Test name",
                Description = "Test description",
                Tiers = TierCollections.Null()?.ToList(),
                Entities = EntityCollections.Normal().ToList()
            };
        }


        public static TierList WithEmptyEntities()
        {
            return new TierList()
            {
                Name = "Test name",
                Description = "Test description",
                Tiers = TierCollections.Normal().ToList(),
                Entities = EntityCollections.Empty().ToList()
            };
        }

        public static TierList WithNullEntities()
        {
            return new TierList()
            {
                Name = "Test name",
                Description = "Test description",
                Tiers = TierCollections.Normal().ToList(),
                Entities = EntityCollections.Null()?.ToList()
            };
        }
    }
}
