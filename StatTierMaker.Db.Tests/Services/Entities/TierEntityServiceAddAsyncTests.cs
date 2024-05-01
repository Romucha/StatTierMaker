using StatTierMaker.API.Tiers;
using StatTierMaker.Db.Repositories;
using StatTierMaker.Db.Services;
using StatTierMaker.Tests.Common.TestDbData.Entities.Add;
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
        public async Task AddAsync_Normal()
        {
            //arrange
            var request = SingularAddTierEntityRequests.Normal();

            //act
            var response = await tierEntityService.AddTierEntity(request);

            //assert
            var tierEntityInDb = TierDbContext.TierEntities.Entry(Mapper.Map<TierEntity>(request)).Entity;
            Assert.NotNull(tierEntityInDb);
            Assert.NotNull(response);
            Assert.NotEqual(0, response.Id);
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenRequestIsInvalid()
        {
            //arrange
            var tierEntity = SingularAddTierEntityRequests.Invalid();

            //act
            await Assert.ThrowsAsync<ValidationException>(async () => await tierEntityService.AddTierEntity(tierEntity));
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenRequestIsDefault()
        {
            //arrange
            var tierEntity = SingularAddTierEntityRequests.Default();

            //act
            await Assert.ThrowsAsync<ValidationException>(async () => await tierEntityService.AddTierEntity(tierEntity));
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenRequestIsNull()
        {
            //arrange
            var tierEntity = SingularAddTierEntityRequests.Null();

            //act && assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await tierEntityService.AddTierEntity(tierEntity));
        }
    }
}
