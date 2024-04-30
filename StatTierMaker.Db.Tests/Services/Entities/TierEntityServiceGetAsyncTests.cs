using StatTierMaker.Db.DTO.Requests.Entities;
using StatTierMaker.Db.Repositories;
using StatTierMaker.Db.Services;
using StatTierMaker.Tests.Common.TestAPIData.Entities;
using StatTierMaker.Tests.Common.TestDbData.Entities.Add;
using StatTierMaker.Tests.Common.TestDbData.Entities.Get;
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
        public async Task GetAsync_Normal()
        {
            //arrange
            var entity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(entity);
            await TierDbContext.SaveChangesAsync();

            var id = TierDbContext.TierEntities.Entry(entity).Entity.Id;
            var request = SingularGetTierEntityRequests.Normal(id);
            //act
            var response = await tierEntityService.GetTierEntity(request);
            //assert
            Assert.NotNull(response);
            Assert.Equal(id, response.Id);
            Assert.Equal(entity.Name, response.Name);
            Assert.Equal(entity.Description, response.Description);
            Assert.Equal(entity.TierId, response.TierId);
            Assert.Equal(entity.TierEntityParameters.Count, response.TierEntityParameters.Count);
        }

        [Fact]
        public async Task GetAsync_ReturnsNull_WhenRequestIsInvalid()
        {
            //arrange
            var entity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(entity);
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetTierEntityRequests.Invalid();
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierEntityService.GetTierEntity(request));
        }

        [Fact]
        public async Task GetAsync_ThrowsException_WhenRequestIsDefault()
        {
            //arrange
            var entity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(entity);
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetTierEntityRequests.Default();
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierEntityService.GetTierEntity(request));
        }

        [Fact]
        public async Task GetAsync_ThrowsException_WhenRequestIsNull()
        {
            //arrange
            var entity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(entity);
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetTierEntityRequests.Null();
            //act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await tierEntityService.GetTierEntity(request));
        }
    }
}
