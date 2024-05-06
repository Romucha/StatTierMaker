using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.Db.Services;
using StatTierMaker.Tests.Common.TestAPIData.Tiers;
using StatTierMaker.Tests.Common.TestDbData.Tiers.Get;
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
        public async Task GetAsync_Normal()
        {
            //arrange
            var tier = SingularTiers.Normal();
            await TierDbContext.AddAsync(tier);
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetTierRequests.Normal(tier.Id);
            //act
            var response = await tierService.GetTier(request);
            //assert
            Assert.NotNull(response);
            Assert.Equal(tier.Id, response.Id);
            Assert.Equal(tier.Name, response.Name);
            Assert.Equal(tier.Description, response.Description);
            Assert.Equal(tier.Value, response.Value);
            Assert.NotNull(response.Entities);
            Assert.Equal(tier.Entities.Count, response.Entities.Count);
        }

        [Fact]
        public async Task GetAsync_ThrowsException_WhenRequestIsInvalid()
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
        public async Task GetAsync_ThrowsException_WhenRequestIsDefault()
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
        public async Task GetAsync_ThrowsException_WhenRequestIsNull()
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
