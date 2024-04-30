using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.Services;
using StatTierMaker.Tests.Common.TestAPIData.Entities;
using StatTierMaker.Tests.Common.TestAPIData.Parameters;
using StatTierMaker.Tests.Common.TestDbData.Parameters.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Services.Parameters
{
    public partial class TierParameterServiceTests
    {
        [Fact]
        public async Task AddAsync_Normal()
        {
            //arrange
            var entity = SingularEntities.Normal();
            await TierDbContext.AddAsync(entity);
            var tierEntityId = TierDbContext.TierEntities.Entry(entity).Entity.Id;
            await TierDbContext.SaveChangesAsync();

            var request = SingularAddTierParameterRequests.Normal(tierEntityId);
            //act
            var response = await tierParameterService.AddTierParameter(request);
            //assert
            var parameter = await TierDbContext.TierParameters.FindAsync(response.Id);
            Assert.NotNull(parameter);
            Assert.Equal(request.TierEntityId, parameter.TierEntityId);
            Assert.Equal(request.Name, parameter.Name);
            Assert.Equal(request.Description, parameter.Description);
            Assert.Equal(request.Name, parameter.Name);
        }
    }
}
