using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Repositories.Parameters
{
    public partial class ParameterRepositoryTests : BaseRepositoryTests<TierParameter>
    {
        public ParameterRepositoryTests() :base()
        {
            Repository = new Repository<TierParameter>(TierDbContext, new NullLogger<Repository<TierParameter>>(), validator);
        }
    }
}
