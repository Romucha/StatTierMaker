using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Tiers;
using StatTierMaker.API.Validation;
using StatTierMaker.Db.Repositories;
using StatTierMaker.Tests.Common.TestData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Repositories.Entites
{
    public partial class EntityRepositoryTests : BaseRepositoryTests<TierEntity>
    {
        public EntityRepositoryTests() : base()
        {
            ILogger<Repository<TierEntity>> logger = new NullLogger<Repository<TierEntity>>();
            Repository = new Repository<TierEntity>(TierDbContext, logger, validator);
        }
    }
}
