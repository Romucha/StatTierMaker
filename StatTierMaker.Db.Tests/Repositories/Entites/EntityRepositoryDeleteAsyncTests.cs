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
        public async Task DeleteAsync_Normal()
        {
            //arrange
            var originalTierEntity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(originalTierEntity);
            await TierDbContext.SaveChangesAsync();
            var id = TierDbContext.TierEntities.Entry(originalTierEntity).Entity.Id;
            //act
            await Repository.DeleteAsync(id);
            //assert
            Assert.Null(await TierDbContext.TierEntities.FindAsync(id));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task DeleteAsync_ThrowsException_WhenIdIsInvalid(int id)
        {
            //arrange
            var originalTierEntity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(originalTierEntity);
            await TierDbContext.SaveChangesAsync();
            //act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await Repository.DeleteAsync(id));
        }
    }
}
