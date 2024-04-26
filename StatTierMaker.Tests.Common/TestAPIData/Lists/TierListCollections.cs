using StatTierMaker.API.Tiers;
using StatTierMaker.Tests.Common.TestAPIData.Entities;
using StatTierMaker.Tests.Common.TestAPIData.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestAPIData.Lists
{
    public static class TierListCollections
    {
        public static IEnumerable<TierList> Normal()
        {
            yield return new TierList()
            {
                Name = "Tier list 1",
                Description = "Tier list description 1",
                Entities = EntityCollections.Normal().ToList(),
                Tiers = TierCollections.Normal().ToList()
            };
            yield return new TierList()
            {
                Name = "Tier list 2",
                Description = "Tier list description 2",
                Entities = EntityCollections.Normal().ToList(),
                Tiers = TierCollections.Normal().ToList()
            };
            yield return new TierList()
            {
                Name = "Tier list 3",
                Description = "Tier list description 3",
                Entities = EntityCollections.Normal().ToList(),
                Tiers = TierCollections.Normal().ToList()
            };
        }

        public static IEnumerable<TierList> WithInvalidTierLists()
        {
            yield return new TierList()
            {
                Name = "",
                Description = "Tier list description 1",
                Entities = EntityCollections.Normal().ToList(),
                Tiers = TierCollections.Normal().ToList()
            };
            yield return new TierList();
            yield return new TierList()
            {
                Name = "Tier list 3",
                Description = "Tier list description 3",
                Entities = null,
                Tiers = TierCollections.Normal().ToList()
            };
        }

        public static IEnumerable<TierList> Empty()
        {
            return Enumerable.Empty<TierList>();
        }

        public static IEnumerable<TierList>? Null()
        {
            return null;
        }
    }
}
