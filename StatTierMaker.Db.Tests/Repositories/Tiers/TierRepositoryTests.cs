using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Repositories.Tiers
{
    public partial class TierRepositoryTests : BaseRepositoryTests<Tier>
    {
        public TierRepositoryTests() : base()
        {
            Repository = new Repository<Tier>(TierDbContext, new NullLogger<Repository<Tier>>(), validator);
        }
    }
}
