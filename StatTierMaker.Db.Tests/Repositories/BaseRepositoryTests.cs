using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using Moq;
using StatTierMaker.API.Validation;
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

        protected IValidator Validator { get; set; }

        public BaseRepositoryTests()
        {
            IConfiguration configuration = new Mock<IConfiguration>().Object;
            DbContextOptions<TierDbContext> dbContextOptions = new DbContextOptionsBuilder<TierDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
                                                                                                           .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;
            TierDbContext = new TierDbContext(dbContextOptions, configuration);

            ILogger<TierValidator> validationLogger = new NullLogger<TierValidator>();
            Validator =  new TierValidator(validationLogger);
        }
    }
}
