using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestData.Parameters
{
    public static class ParameterCollections
    {
        public static IEnumerable<TierParameter> Normal()
        {
            yield return new TierParameter()
            {
                Name = "Name 1",
                Description = "Description 1",
                Value = TierValue.F,
                Coefficient = 1,
            };
            yield return new TierParameter()
            {
                Name = "Name 2",
                Description = "Description 2",
                Value = TierValue.S,
                Coefficient = 3,
            };
            yield return new TierParameter()
            {
                Name = "Name 3",
                Description = "Description 3",
                Value = TierValue.B,
                Coefficient = 2,
            };
        }

        public static IEnumerable<TierParameter> WithInvalidElements() 
        {
            yield return new TierParameter()
            {
                Name = "Name 1",
                Description = "Description 1",
                Value = TierValue.F,
                Coefficient = 1,
            };
            yield return new TierParameter()
            {
                Name = null,
                Description = "Description 2",
                Value = TierValue.S,
                Coefficient = 3,
            };
            yield return new TierParameter()
            {
                Name = "Name 3",
                Description = "Description 3",
                Value = TierValue.B,
                Coefficient = 0,
            };
        }

        public static IEnumerable<TierParameter> Empty()
        {
            return Enumerable.Empty<TierParameter>();
        }

        public static IEnumerable<TierParameter?> WithNullElements()
        {
            yield return new TierParameter()
            {
                Name = "Name 1",
                Description = "Description 1",
                Value = TierValue.F,
                Coefficient = 1,
            };
            yield return null;
            yield return new TierParameter()
            {
                Name = "Name 3",
                Description = "Description 3",
                Value = TierValue.B,
                Coefficient = 0,
            };
        }

        public static IEnumerable<TierParameter>? Null()
        {
            return null;
        }
    }
}
