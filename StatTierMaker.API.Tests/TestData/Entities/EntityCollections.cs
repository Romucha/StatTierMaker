using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tests.TestData.Entities
{
    /// <summary>
    /// Collections of entities for usage in different tests.
    /// </summary>
    internal static class EntityCollections
    {
        public static IEnumerable<TierEntity> Normal()
        {
            yield return new TierEntity()
            {
                Name = "Entity 1",
                Description = "Description",
                TierEntityParameters = new List<TierParameter>
                {
                    new TierParameter()
                    {
                        Name = "Parameter 1",
                        Description = "Description",
                        Value = TierValue.F,
                        Coefficient = 1
                    },
                    new TierParameter()
                    {
                        Name = "Parameter 2",
                        Description = "Description",
                        Value = TierValue.F,
                        Coefficient = 1
                    },
                    new TierParameter()
                    {
                        Name = "Parameter 3",
                        Description = "Description",
                        Value = TierValue.F,
                        Coefficient = 1
                    }
                }
            };
            yield return new()
            {
                Name = "Entity 2",
                Description = "Description",
                TierEntityParameters = new List<TierParameter>
                {
                    new TierParameter()
                    {
                        Name = "Parameter 1",
                        Description = "Description",
                        Value = TierValue.E,
                        Coefficient = 1
                    },
                    new TierParameter()
                    {
                        Name = "Parameter 2",
                        Description = "Description",
                        Value = TierValue.E,
                        Coefficient = 1
                    },
                    new TierParameter()
                    {
                        Name = "Parameter 3",
                        Description = "Description",
                        Value = TierValue.E,
                        Coefficient = 1
                    }
                }
            };
            yield return new()
            {
                Name = "Entity 3",
                Description = "Description",
                TierEntityParameters = new List<TierParameter>
                {
                    new TierParameter()
                    {
                        Name = "Parameter 1",
                        Description = "Description",
                        Value = TierValue.D,
                        Coefficient = 1
                    },
                    new TierParameter()
                    {
                        Name = "Parameter 2",
                        Description = "Description",
                        Value = TierValue.D,
                        Coefficient = 1
                    },
                    new TierParameter()
                    {
                        Name = "Parameter 3",
                        Description = "Description",
                        Value = TierValue.D,
                        Coefficient = 1
                    }
                }
            };
            yield return new()
            {
                Name = "Entity 4",
                Description = "Description",
                TierEntityParameters = new List<TierParameter>
                {
                    new TierParameter()
                    {
                        Name = "Parameter 1",
                        Description = "Description",
                        Value = TierValue.C,
                        Coefficient = 1
                    },
                    new TierParameter()
                    {
                        Name = "Parameter 2",
                        Description = "Description",
                        Value = TierValue.C,
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
            yield return new()
            {
                Name = "Entity 5",
                Description = "Description",
                TierEntityParameters = new List<TierParameter>
                {
                    new TierParameter()
                    {
                        Name = "Parameter 1",
                        Description = "Description",
                        Value = TierValue.B,
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
                        Value = TierValue.B,
                        Coefficient = 1
                    }
                }
            };
        }

        public static IEnumerable<TierEntity> WithInvalidElements()
        {
            yield return new()
            {
                Name = null,
                Description = null,
            };
            yield return new()
            {
                Name = "",
                Description = "",
                TierEntityParameters = null
            };
        }

        public static IEnumerable<TierEntity?> WithNullElements()
        {
            yield return new();
            yield return null;
        }

        public static IEnumerable<TierEntity> Empty()
        {
            return Enumerable.Empty<TierEntity>();
        }

        public static IEnumerable<TierEntity>? Null()
        {
            return null;
        }
    }
}
