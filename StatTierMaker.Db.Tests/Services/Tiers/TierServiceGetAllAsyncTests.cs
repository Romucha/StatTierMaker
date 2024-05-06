using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.Db.Services;
using StatTierMaker.Tests.Common.TestAPIData.Tiers;
using StatTierMaker.Tests.Common.TestDbData.Tiers.GetAll;
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
        public async Task GetAllAsync_Normal()
        {
            //arrange
            var tier = SingularTiers.Normal();
            await TierDbContext.AddRangeAsync(tier);
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetTiersRequests.Normal();
            //act
            var response = await tierService.GetTiers(request);
            //assert
            Assert.NotNull(response);
            Assert.NotNull(response.Tiers);
            Assert.NotEmpty(response.Tiers);
        }

        [Fact]
        public async Task GetAllAsync_Normal_WhenRequestIsDefault()
        {
            //arrange
            var tier = SingularTiers.Normal();
            await TierDbContext.AddRangeAsync(tier);
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetTiersRequests.Default();
            //act
            var response = await tierService.GetTiers(request);
            //assert
            Assert.NotNull(response);
            Assert.NotNull(response.Tiers);
            Assert.NotEmpty(response.Tiers);
        }

        [Fact]
        public async Task GetAllAsync_ThrowsException_WhenRequestIsInvalid()
        {
            //arrange
            var tier = SingularTiers.Normal();
            await TierDbContext.AddRangeAsync(tier);
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetTiersRequests.Invalid();
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierService.GetTiers(request));
        }

        [Fact]
        public async Task GetAllAsync_ThrowsException_WhenRequestIsNull()
        {
            //arrange
            var tier = SingularTiers.Normal();
            await TierDbContext.AddRangeAsync(tier);
            await TierDbContext.SaveChangesAsync();

            var request = SingularGetTiersRequests.Null();
            //act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await tierService.GetTiers(request));
        }
    }
}
