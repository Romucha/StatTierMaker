using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Tiers;
using StatTierMaker.API.Validation;
using StatTierMaker.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Repositories
{
    public class RepositoryTests : BaseRepositoryTests<TierEntity>
    {
        public RepositoryTests()
        {
            ILogger<Repository<TierEntity>> logger = new NullLogger<Repository<TierEntity>>();
            ILogger<TierValidator> validationLogger = new NullLogger<TierValidator>();
            IValidator validator = new TierValidator(validationLogger);
            Repository = new Repository<TierEntity>(TierDbContext, logger, validator);
        }

        [Fact]
        public async Task GetAsync_Normal()
        {
            //arrange
            var originalTierEntity = new TierEntity()
            {
                Name = "Test",
                Description = "Test",
                TierEntityParameters = []
            };
            await TierDbContext.TierEntities.AddAsync(originalTierEntity);
            await TierDbContext.SaveChangesAsync();
            //act
            var tierlist = await Repository.GetAsync(TierDbContext.TierEntities.FirstOrDefault().Id);
            //assert
            Assert.NotNull(tierlist);
            Assert.Equal(originalTierEntity, tierlist);
        }

        [Fact]
        public async Task GetAllAsync_Normal()
        {
            //arrange
            var originalTierEntityList = new List<TierEntity>()
            {
                new TierEntity()
                {
                    Name = "Test 1",
                    Description = "Test 1",
                    TierEntityParameters = []
                },
                new TierEntity()
                {
                    Name = "Test 2",
                    Description = "Test 2",
                    TierEntityParameters = []
                },
                new TierEntity()
                {
                    Name = "Test 3",
                    Description = "Test 3",
                    TierEntityParameters = []
                }
            };
            await TierDbContext.TierEntities.AddRangeAsync(originalTierEntityList);
            await TierDbContext.SaveChangesAsync();
            //act
            var results = await Repository.GetAllAsync();
            //assert
            Assert.NotNull(results);
            Assert.NotEmpty(results);
        }

        //TBD
    }
}
