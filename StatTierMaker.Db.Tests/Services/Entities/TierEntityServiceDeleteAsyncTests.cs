using StatTierMaker.API.Tiers;
using StatTierMaker.Db.Repositories;
using StatTierMaker.Db.Services;
using StatTierMaker.Tests.Common.TestAPIData.Entities;
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
            var tierEntity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(tierEntity);
            await TierDbContext.SaveChangesAsync();

            var id = TierDbContext.TierEntities.Entry(tierEntity).Entity.Id;
            var request = SingularDeleteTierEntityRequests.Normal(id);
            //act
            var response = await tierEntityService.DeleteTierEntity(request);
            //assert
            Assert.Null(await TierDbContext.TierEntities.FindAsync(id));
            Assert.NotNull(response);
            Assert.NotEqual(0, response.Id);
        }

        [Fact]
        public async Task DeleteAsync_ThrowsException_WhenRequestIsInvalid()
        {
            //arrange
            var tierEntity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(tierEntity);
            await TierDbContext.SaveChangesAsync();

            var id = TierDbContext.TierEntities.Entry(tierEntity).Entity.Id;
            var tierEntityRequest = SingularDeleteTierEntityRequests.Invalid();
            //act
            await Assert.ThrowsAsync<ValidationException>(async () => await tierEntityService.DeleteTierEntity(tierEntityRequest));
            //assert
            Assert.NotNull(await TierDbContext.TierEntities.FindAsync(id));
        }

        [Fact]
        public async Task DeleteAsync_ThrowsException_WhenRequestIsDefault()
        {
            //arrange
            var tierEntity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(tierEntity);
            await TierDbContext.SaveChangesAsync();

            var id = TierDbContext.TierEntities.Entry(tierEntity).Entity.Id;
            var tierEntityRequest = SingularDeleteTierEntityRequests.Default();
            //act
            await Assert.ThrowsAsync<ValidationException>(async () => await tierEntityService.DeleteTierEntity(tierEntityRequest));
            //assert
            Assert.NotNull(await TierDbContext.TierEntities.FindAsync(id));
        }

        [Fact]
        public async Task DeleteAsync_ThrowsException_WhenRequestIsNull()
        {
            //arrange
            var tierEntity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(tierEntity);
            await TierDbContext.SaveChangesAsync();

            var id = TierDbContext.TierEntities.Entry(tierEntity).Entity.Id;
            var tierEntityRequest = SingularDeleteTierEntityRequests.Null();
            //act
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await tierEntityService.DeleteTierEntity(tierEntityRequest));
            //assert
            Assert.NotNull(await TierDbContext.TierEntities.FindAsync(id));
        }
    }
}
