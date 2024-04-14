using StatTierMaker.Tests.Common.TestData.Entities;
using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestData.Tiers
{
    public static class TierCollections
    {
        public static IEnumerable<Tier> Normal()
        {
            yield return new Tier()
            {
                Name = "A Tier",
                Description = "Description A",
                Entities = [],
                Value = TierValue.A
            };
            yield return new Tier()
            {
                Name = "B Tier",
                Description = "Description B",
                Entities = [],
                Value = TierValue.B
            };
            yield return new Tier()
            {
                Name = "C Tier",
                Description = "Description C",
                Entities = [],
                Value = TierValue.C
            };
            yield return new Tier()
            {
                Name = "D Tier",
                Description = "Description D",
                Entities = [],
                Value = TierValue.D
            };
            yield return new Tier()
            {
                Name = "E Tier",
                Description = "Description E",
                Entities = [],
                Value = TierValue.E
            };
            yield return new Tier()
            {
                Name = "F Tier",
                Description = "Description F",
                Entities = [],
                Value = TierValue.F
            };

            yield return new Tier()
            {
                Name = "S Tier",
                Description = "Description S",
                Entities = [],
                Value = TierValue.S
            };
        }

        public static IEnumerable<Tier> WithInvalidElements()
        {
            yield return new Tier()
            {
                Name = "",
                Description = "Tier description",
                Entities = new List<TierEntity>(),
                Value = TierValue.F
            };
            yield return new Tier()
            {
                Name = "Tier name",
                Description = null,
                Entities = null,
                Value = TierValue.F
            };
        }

        public static IEnumerable<Tier?> WithNullElements()
        {
            yield return new Tier()
            {
                Name = "Tier name",
                Description = "Tier description",
                Entities = new List<TierEntity>(),
                Value = TierValue.F
            };
            yield return null;
        }

        public static IEnumerable<Tier> Empty()
        {
            return Enumerable.Empty<Tier>();
        }

        public static IEnumerable<Tier>? Null()
        {
            return null;
        }
    }
}
