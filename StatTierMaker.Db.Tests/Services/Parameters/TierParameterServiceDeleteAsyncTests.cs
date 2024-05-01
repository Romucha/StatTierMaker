using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.Services;
using StatTierMaker.Tests.Common.TestAPIData.Entities;
using StatTierMaker.Tests.Common.TestAPIData.Parameters;
using StatTierMaker.Tests.Common.TestDbData.Parameters.Add;
using StatTierMaker.Tests.Common.TestDbData.Parameters.Delete;
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
        public async Task DeleteAsync_Normal()
        {
            //arrange
            var entity = SingularEntities.Normal();
            await TierDbContext.AddAsync(entity);
            var tierEntityId = TierDbContext.TierEntities.Entry(entity).Entity.Id;
            var parameter = SingularParameters.Normal();
            parameter.TierEntityId = tierEntityId;
            await TierDbContext.AddAsync(parameter);
            await TierDbContext.SaveChangesAsync();

            var request = SingularDeleteTierParameterRequests.Normal(parameter.Id);
            //act
            var response = await tierParameterService.DeleteTierParameter(request);
            //assert
            var parameterInDb = await TierDbContext.TierParameters.FindAsync(response.Id);
            Assert.Null(parameterInDb);
        }

        [Fact]
        public async Task DeleteAsync_ThrowsException_WhenRequestIsInvalid()
        {
            //arrange
            var request = SingularDeleteTierParameterRequests.Invalid();
            //act && assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierParameterService.DeleteTierParameter(request));
        }

        [Fact]
        public async Task DeleteAsync_ThrowsException_WhenRequestIsDefault()
        {
            //arrange
            var request = SingularDeleteTierParameterRequests.Default();
            //act && assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierParameterService.DeleteTierParameter(request));
        }

        [Fact]
        public async Task DeleteAsync_ThrowsException_WhenRequestIsNull()
        {
            //arrange
            var request = SingularDeleteTierParameterRequests.Null();
            //act && assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await tierParameterService.DeleteTierParameter(request));
        }
    }
}
