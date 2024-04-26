using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Repositories.Lists
{
    public partial class ListRepositoryTests : BaseRepositoryTests<TierList>
    {
        public ListRepositoryTests() : base()
        {
            Repository = new Repository<TierList>(TierDbContext, new NullLogger<Repository<TierList>>(), Validator);
        }
    }
}
