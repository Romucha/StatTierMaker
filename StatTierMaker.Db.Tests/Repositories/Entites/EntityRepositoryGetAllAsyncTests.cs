using StatTierMaker.Tests.Common.TestAPIData.Entities;
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
        public async Task GetAllAsync_Normal()
        {
            //arrange
            var originalTierEntityList = EntityCollections.Normal();
            await TierDbContext.TierEntities.AddRangeAsync(originalTierEntityList);
            await TierDbContext.SaveChangesAsync();
            //act
            var results = await Repository.GetAllAsync();
            //assert
            Assert.NotNull(results);
            Assert.NotEmpty(results);
        }
    }
}
