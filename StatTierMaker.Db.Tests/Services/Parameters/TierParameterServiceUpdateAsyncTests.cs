using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.Services;
using StatTierMaker.Tests.Common.TestAPIData.Entities;
using StatTierMaker.Tests.Common.TestAPIData.Lists;
using StatTierMaker.Tests.Common.TestAPIData.Parameters;
using StatTierMaker.Tests.Common.TestAPIData.Tiers;
using StatTierMaker.Tests.Common.TestDbData.Parameters.Add;
using StatTierMaker.Tests.Common.TestDbData.Parameters.Delete;
using StatTierMaker.Tests.Common.TestDbData.Parameters.Get;
using StatTierMaker.Tests.Common.TestDbData.Parameters.GetAll;
using StatTierMaker.Tests.Common.TestDbData.Parameters.Update;
using StatTierMaker.Tests.Common.TestDbData.Tiers.Update;
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
        public async Task UpdateAsync_Normal()
        {
            //arrange
            var tierParameter = SingularParameters.Normal();
            await TierDbContext.AddAsync(tierParameter);

            var tierEntity = SingularEntities.Normal();
            await TierDbContext.AddAsync(tierEntity);

            var tier = SingularTiers.Normal();
            await TierDbContext.AddAsync(tier);

            var tierList = SingularLists.Normal();
            await TierDbContext.AddAsync(tierList);

            tierParameter.TierEntityId = tierEntity.Id;
            tierEntity.TierId = tier.Id;
            tier.TierListId = tierList.Id;

            await TierDbContext.SaveChangesAsync();
            TierDbContext.ChangeTracker.Clear();

            var request = SingularUpdateTierParameterRequests.Normal(tierParameter.Id, tierEntity.Id);
            //act
            var response = await tierParameterService.UpdateTierParameter(request);
            //assert
            var updatedTierParameter = await TierDbContext.TierParameters.FindAsync(response.Id);
            Assert.NotNull(response);
            Assert.NotNull(updatedTierParameter);
            Assert.Equal(updatedTierParameter.Id, response.Id);
            Assert.Equal(request.Id, updatedTierParameter.Id);
            Assert.Equal(request.Name, updatedTierParameter.Name);
            Assert.Equal(request.Description, updatedTierParameter.Description);
            Assert.Equal(request.Value, updatedTierParameter.Value);
            Assert.Equal(request.Coefficient, updatedTierParameter.Coefficient);
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenRequestIsInvalid()
        {
            //arrange
            var tierParameter = SingularParameters.Normal();
            await TierDbContext.AddAsync(tierParameter);

            var tierEntity = SingularEntities.Normal();
            await TierDbContext.AddAsync(tierEntity);

            var tier = SingularTiers.Normal();
            await TierDbContext.AddAsync(tier);

            var tierList = SingularLists.Normal();
            await TierDbContext.AddAsync(tierList);

            tierParameter.TierEntityId = tierEntity.Id;
            tierEntity.TierId = tier.Id;
            tier.TierListId = tierList.Id;

            await TierDbContext.SaveChangesAsync();
            TierDbContext.ChangeTracker.Clear();

            var request = SingularUpdateTierParameterRequests.Invalid();
            //act
            await Assert.ThrowsAsync<ValidationException>(async () => await tierParameterService.UpdateTierParameter(request));
            //assert
            var updatedTierParameter = await TierDbContext.TierParameters.FindAsync(tierParameter.Id);
            Assert.NotNull(updatedTierParameter);
            Assert.NotEqual(request.Id, updatedTierParameter.Id);
            Assert.NotEqual(request.Name, updatedTierParameter.Name);
            Assert.NotEqual(request.Description, updatedTierParameter.Description);
            Assert.NotEqual(request.Value, updatedTierParameter.Value);
            Assert.NotEqual(request.Coefficient, updatedTierParameter.Coefficient);
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenRequestIsDefault()
        {
            //arrange
            var tierParameter = SingularParameters.Normal();
            await TierDbContext.AddAsync(tierParameter);

            var tierEntity = SingularEntities.Normal();
            await TierDbContext.AddAsync(tierEntity);

            var tier = SingularTiers.Normal();
            await TierDbContext.AddAsync(tier);

            var tierList = SingularLists.Normal();
            await TierDbContext.AddAsync(tierList);

            tierParameter.TierEntityId = tierEntity.Id;
            tierEntity.TierId = tier.Id;
            tier.TierListId = tierList.Id;

            await TierDbContext.SaveChangesAsync();
            TierDbContext.ChangeTracker.Clear();

            var request = SingularUpdateTierParameterRequests.Default();
            //act
            await Assert.ThrowsAsync<ValidationException>(async () => await tierParameterService.UpdateTierParameter(request));
            //assert
            var updatedTierParameter = await TierDbContext.TierParameters.FindAsync(tierParameter.Id);
            Assert.NotNull(updatedTierParameter);
            Assert.NotEqual(request.Id, updatedTierParameter.Id);
            Assert.NotEqual(request.Name, updatedTierParameter.Name);
            Assert.NotEqual(request.Description, updatedTierParameter.Description);
            Assert.NotEqual(request.Value, updatedTierParameter.Value);
            Assert.NotEqual(request.Coefficient, updatedTierParameter.Coefficient);
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenRequestIsNull()
        {
            //arrange
            var tierParameter = SingularParameters.Normal();
            await TierDbContext.AddAsync(tierParameter);

            var tierEntity = SingularEntities.Normal();
            await TierDbContext.AddAsync(tierEntity);

            var tier = SingularTiers.Normal();
            await TierDbContext.AddAsync(tier);

            var tierList = SingularLists.Normal();
            await TierDbContext.AddAsync(tierList);

            tierParameter.TierEntityId = tierEntity.Id;
            tierEntity.TierId = tier.Id;
            tier.TierListId = tierList.Id;

            await TierDbContext.SaveChangesAsync();
            TierDbContext.ChangeTracker.Clear();

            var request = SingularUpdateTierParameterRequests.Null();
            //act
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await tierParameterService.UpdateTierParameter(request));
            //assert
            var updatedTierParameter = await TierDbContext.TierParameters.FindAsync(tierParameter.Id);
            Assert.NotNull(updatedTierParameter);
        }
    }
}
