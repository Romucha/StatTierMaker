using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Moq;
using StatTierMaker.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Repositories
{
    public class BaseRepositoryTests<T> where T : class
    {
        protected IRepository<T> Repository { get; set; } = default!;

        protected TierDbContext TierDbContext { get; set; }

        public BaseRepositoryTests()
        {
            IConfiguration configuration = new Mock<IConfiguration>().Object;
            DbContextOptions<TierDbContext> dbContextOptions = new DbContextOptionsBuilder<TierDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
                                                                                                           .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;
            TierDbContext = new TierDbContext(dbContextOptions, configuration);
        }
    }
}
