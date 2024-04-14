﻿using StatTierMaker.API.Tiers;
using StatTierMaker.Tests.Common.TestData.Entities;
using StatTierMaker.Tests.Common.TestData.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestData.Lists
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
    }
}
