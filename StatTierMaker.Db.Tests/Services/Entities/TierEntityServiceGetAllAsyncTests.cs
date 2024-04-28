using StatTierMaker.Db.DTO.Requests.Entities;
using StatTierMaker.Db.Repositories;
using StatTierMaker.Db.Services;
using StatTierMaker.Tests.Common.TestAPIData.Entities;
using StatTierMaker.Tests.Common.TestDbData.Entities.GetAll;
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
        public async Task GetAllAsync_Normal()
        {
            //arrange
            await TierDbContext.AddRangeAsync(EntityCollections.Normal());
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetAllTierEntitiesRequests.Normal();
            //act
            var response = await tierEntityService.GetTierEntities(request);
            //assert
            Assert.NotNull(response);
            Assert.NotEmpty(response.Entities);
        }

        [Fact]
        public async Task GetAllAsync_ThrowsException_WhenRequestIsInvalid()
        {
            //arrange
            await TierDbContext.AddRangeAsync(EntityCollections.Normal());
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetAllTierEntitiesRequests.Invalid();
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () =>await tierEntityService.GetTierEntities(request));
        }

        [Fact]
        public async Task GetAllAsync_ThrowsException_WhenRequestIsDefault()
        {
            //arrange
            await TierDbContext.AddRangeAsync(EntityCollections.Normal());
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetAllTierEntitiesRequests.Default();
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierEntityService.GetTierEntities(request));
        }

        [Fact]
        public async Task GetAllAsync_ThrowsException_WhenRequestIsNull()
        {
            //arrange
            await TierDbContext.AddRangeAsync(EntityCollections.Normal());
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetAllTierEntitiesRequests.Null();
            //act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await tierEntityService.GetTierEntities(request));
        }
    }
}
