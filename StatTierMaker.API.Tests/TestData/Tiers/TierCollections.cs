using StatTierMaker.API.Tests.TestData.Entities;
using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tests.TestData.Tiers
{
    internal static class TierCollections
    {
        public static IEnumerable<Tier> Normal()
        {
            yield return new Tier()
            {
                Name = "Tier 1",
                Description = "Description 1",
                Entities = new List<TierEntity>(EntityCollections.Normal()),
                Value = TierValue.A
            };
            yield return new Tier()
            {
                Name = "Tier 2",
                Description = "Description 2",
                Entities = new List<TierEntity>(EntityCollections.Normal()),
                Value = TierValue.B
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
