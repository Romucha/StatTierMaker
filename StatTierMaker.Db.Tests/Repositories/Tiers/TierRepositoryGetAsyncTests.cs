using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.Repositories;
using StatTierMaker.Tests.Common.TestData.Tiers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Repositories.Tiers
{
    public partial class TierRepositoryTests
    {
        [Fact]
        public async Task GetAsync_Normal()
        {
            //arrange
            var tier = SingularTiers.Normal();
            await TierDbContext.Tiers.AddAsync(tier);
            await TierDbContext.SaveChangesAsync();
            var id = TierDbContext.Tiers.Entry(tier).Entity.Id;
            //act
            var result = await Repository.GetAsync(id);
            //assert
            Assert.NotNull(result);
            Assert.Equal(TierDbContext.Tiers.Entry(tier).Entity, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task GetAsync_ReturnsNull_WhenIdIsInvalid(int id)
        {
            //arrange
            var tier = SingularTiers.Normal();
            await TierDbContext.Tiers.AddAsync(tier);
            await TierDbContext.SaveChangesAsync();
            //act
            var result = await Repository.GetAsync(id);
            //assert
            Assert.Null(result);
        }
    }
}
