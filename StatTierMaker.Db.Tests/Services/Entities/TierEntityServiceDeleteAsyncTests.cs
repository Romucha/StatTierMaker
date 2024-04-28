using StatTierMaker.API.Tiers;
using StatTierMaker.Db.Repositories;
using StatTierMaker.Db.Services;
using StatTierMaker.Tests.Common.TestDbData.Entities.Delete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Services.Entities
{
    public partial class TierEntityServiceTests
    {
        [Fact]
        public async Task DeleteAsync_Normal()
        {
            //arrange
            var tierEntity = new TierEntity()
            {
                Name = "Tier Entity Name",
                Description = "Tier Entity Description",
            };
            await TierDbContext.TierEntities.AddAsync(tierEntity);
            await TierDbContext.SaveChangesAsync();

            var id = TierDbContext.TierEntities.Entry(tierEntity).Entity.Id;
            var tierEntityRequest = SingularDeleteTierEntityRequests.Normal(id);
            //act
            await tierEntityService.DeleteTierEntity(tierEntityRequest);
            //assert
            Assert.Null(await TierDbContext.TierEntities.FindAsync(id));
        }

        [Fact]
        public async Task DeleteAsync_ThrowsException_WhenRequestIsInvalid()
        {
            //arrange
            var tierEntity = new TierEntity()
            {
                Name = "Tier Entity Name",
                Description = "Tier Entity Description",
            };
            await TierDbContext.TierEntities.AddAsync(tierEntity);
            await TierDbContext.SaveChangesAsync();

            var id = TierDbContext.TierEntities.Entry(tierEntity).Entity.Id;
            var tierEntityRequest = SingularDeleteTierEntityRequests.Invalid();
            //act
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await tierEntityService.DeleteTierEntity(tierEntityRequest));
            //assert
            Assert.NotNull(await TierDbContext.TierEntities.FindAsync(id));
        }

        [Fact]
        public async Task DeleteAsync_ThrowsException_WhenRequestIsDefault()
        {
            //arrange
            var tierEntity = new TierEntity()
            {
                Name = "Tier Entity Name",
                Description = "Tier Entity Description",
            };
            await TierDbContext.TierEntities.AddAsync(tierEntity);
            await TierDbContext.SaveChangesAsync();

            var id = TierDbContext.TierEntities.Entry(tierEntity).Entity.Id;
            var tierEntityRequest = SingularDeleteTierEntityRequests.Default();
            //act
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await tierEntityService.DeleteTierEntity(tierEntityRequest));
            //assert
            Assert.NotNull(await TierDbContext.TierEntities.FindAsync(id));
        }

        [Fact]
        public async Task DeleteAsync_ThrowsException_WhenRequestIsNull()
        {
            //arrange
            var tierEntity = new TierEntity()
            {
                Name = "Tier Entity Name",
                Description = "Tier Entity Description",
            };
            await TierDbContext.TierEntities.AddAsync(tierEntity);
            await TierDbContext.SaveChangesAsync();

            var id = TierDbContext.TierEntities.Entry(tierEntity).Entity.Id;
            var tierEntityRequest = SingularDeleteTierEntityRequests.Null();
            //act
            await Assert.ThrowsAsync<NullReferenceException>(async () => await tierEntityService.DeleteTierEntity(tierEntityRequest));
            //assert
            Assert.NotNull(await TierDbContext.TierEntities.FindAsync(id));
        }
    }
}
