using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using StatTierMaker.API.Tiers;
using StatTierMaker.API.Validation;
using StatTierMaker.Db.Mapping;
using StatTierMaker.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Services
{
    public abstract class BaseServiceTests
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected readonly TierDbContext TierDbContext;

        protected readonly IMapper Mapper;

        protected IValidator Validator { get; set; }
        protected BaseServiceTests()
        {
            IConfiguration configuration = new Mock<IConfiguration>().Object;
            DbContextOptions<TierDbContext> dbContextOptions = new DbContextOptionsBuilder<TierDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
                                                                                                           .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;
            TierDbContext = new TierDbContext(dbContextOptions, configuration);

            Validator = new TierValidator(new NullLogger<TierValidator>());

            IRepository<TierList> tierListRepository = new Repository<TierList>(TierDbContext, new NullLogger<Repository<TierList>>(), Validator);
            IRepository<Tier> tierRepository = new Repository<Tier>(TierDbContext, new NullLogger<Repository<Tier>>(), Validator);
            IRepository<TierEntity> tierEntityRepository = new Repository<TierEntity>(TierDbContext, new NullLogger<Repository<TierEntity>>(), Validator);
            IRepository<TierParameter> tierParameterRepository = new Repository<TierParameter>(TierDbContext, new NullLogger<Repository<TierParameter>>(), Validator);

            UnitOfWork = new UnitOfWork(tierRepository, tierListRepository, tierEntityRepository, tierParameterRepository, new NullLogger<UnitOfWork>(), TierDbContext);

            MapperConfiguration mapperConfiguration = new MapperConfiguration(c => c.AddProfile(typeof(TierMapperProfile)));
            Mapper = mapperConfiguration.CreateMapper();
        }
    }
}
