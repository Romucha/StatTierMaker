using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.Db.Services;
using StatTierMaker.Tests.Common.TestAPIData.Lists;
using StatTierMaker.Tests.Common.TestAPIData.Tiers;
using StatTierMaker.Tests.Common.TestDbData.Tiers.Get;
using StatTierMaker.Tests.Common.TestDbData.Tiers.Update;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Services.Tiers
{
    public partial class TierServiceTests : BaseServiceTests
    {
        [Fact]
        public async Task UpdateAsync_Normal()
        {
            //arrange
            var tier = SingularTiers.Normal();
            await TierDbContext.AddAsync(tier);

            var tierList = SingularLists.Normal();
            await TierDbContext.AddAsync(tierList);

            tier.TierListId = tierList.Id;

            await TierDbContext.SaveChangesAsync();
            TierDbContext.ChangeTracker.Clear();

            var request = SingularUpdateTierRequests.Normal(tier.Id);
            //act
            var response = await tierService.UpdateTier(request);
            //assert
            Assert.NotNull(response);
            Assert.Equal(tier.Id, response.Id);
            Assert.Equal(request.Id, tier.Id);
            Assert.Equal(request.Name, tier.Name);
            Assert.Equal(request.Description, tier.Description);
            Assert.Equal(request.Value, tier.Value);
            Assert.NotNull(request.Entities);
            Assert.Equal(request.Entities.Count, tier.Entities.Count);
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenRequestIsInvalid()
        {
            //arrange
            var tier = SingularTiers.Normal();
            await TierDbContext.AddAsync(tier);
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetTierRequests.Invalid();
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierService.GetTier(request));
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenRequestIsDefault()
        {
            //arrange
            var tier = SingularTiers.Normal();
            await TierDbContext.AddAsync(tier);
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetTierRequests.Default();
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierService.GetTier(request));
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenRequestIsNull()
        {
            //arrange
            var tier = SingularTiers.Normal();
            await TierDbContext.AddAsync(tier);
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetTierRequests.Null();
            //act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await tierService.GetTier(request));
        }
    }
}
