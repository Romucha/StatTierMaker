using StatTierMaker.Tests.Common.TestData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Repositories.Entites
{
    public partial class EntityRepositoryTests
    {
        [Fact]
        public async Task GetAsync_Normal()
        {
            //arrange
            var originalTierEntity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(originalTierEntity);
            await TierDbContext.SaveChangesAsync();
            //act
            var tierlist = await Repository.GetAsync(TierDbContext.TierEntities.FirstOrDefault().Id);
            //assert
            Assert.NotNull(tierlist);
            Assert.Equal(originalTierEntity, tierlist);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task GetAsync_ReturnsNull_WhenIdIsInvalid(int id)
        {
            //arrange
            var originalTierEntity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(originalTierEntity);
            await TierDbContext.SaveChangesAsync();
            //act
            var entity = await Repository.GetAsync(id);
            //assert
            Assert.Null(entity);
        }
    }
}
