using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.Services;
using StatTierMaker.Tests.Common.TestAPIData.Entities;
using StatTierMaker.Tests.Common.TestAPIData.Parameters;
using StatTierMaker.Tests.Common.TestDbData.Parameters.Add;
using StatTierMaker.Tests.Common.TestDbData.Parameters.Delete;
using StatTierMaker.Tests.Common.TestDbData.Parameters.Get;
using StatTierMaker.Tests.Common.TestDbData.Parameters.GetAll;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Services.Parameters
{
    public partial class TierParameterServiceTests
    {
        [Fact]
        public async Task GetAllAsync_Normal()
        {
            //arrange
            var entity = SingularEntities.Normal();
            await TierDbContext.AddAsync(entity);
            var tierEntityId = TierDbContext.TierEntities.Entry(entity).Entity.Id;
            var parameter = SingularParameters.Normal();
            parameter.TierEntityId = tierEntityId;
            await TierDbContext.AddAsync(parameter);
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetTierParametersRequests.Normal();
            //act
            var response = await tierParameterService.GetTierParameters(request);
            //assert
            Assert.NotNull(response);
            Assert.NotNull(response.Parameters);
            Assert.NotEmpty(response.Parameters);
        }

        [Fact]
        public async Task GetAllAsync_Normal_WhenRequestIsDefault()
        {
            //arrange
            var entity = SingularEntities.Normal();
            await TierDbContext.AddAsync(entity);
            var tierEntityId = TierDbContext.TierEntities.Entry(entity).Entity.Id;
            var parameter = SingularParameters.Normal();
            parameter.TierEntityId = tierEntityId;
            await TierDbContext.AddAsync(parameter);
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetTierParametersRequests.Default();
            //act
            var response = await tierParameterService.GetTierParameters(request);
            //assert
            Assert.NotNull(response);
            Assert.NotNull(response.Parameters);
            Assert.NotEmpty(response.Parameters);
        }

        [Fact]
        public async Task GetAllAsync_ThrowsException_WhenRequestIsInvalid()
        {
            //arrange
            var request = SingularGetTierParametersRequests.Invalid();
            //act && assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierParameterService.GetTierParameters(request));
        }

        [Fact]
        public async Task GetAllAsync_ThrowsException_WhenRequestIsNull()
        {
            //arrange
            var request = SingularGetTierParametersRequests.Null();
            //act && assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await tierParameterService.GetTierParameters(request));
        }
    }
}
