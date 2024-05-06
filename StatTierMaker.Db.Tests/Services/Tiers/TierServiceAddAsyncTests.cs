using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.Services;
using StatTierMaker.Tests.Common.TestDbData.Tiers.Add;
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
        public async Task AddAsync_Normal()
        {
            //arrange
            var tierList = new TierList()
            {
                Name = "Test",
                Description = "Test",
            };
            await TierDbContext.AddAsync(tierList);
            await TierDbContext.SaveChangesAsync();

            var request = SingularAddTierRequests.Normal(tierList.Id);
            //act
            var response = await tierService.AddTier(request);
            //assert
            Assert.NotNull(response);
            Assert.NotEqual(0, response.Id);
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenRequestIsInvalid()
        {
            //arrange
            var tierList = new TierList()
            {
                Name = "Test",
                Description = "Test",
            };
            await TierDbContext.AddAsync(tierList);
            await TierDbContext.SaveChangesAsync();

            var request = SingularAddTierRequests.Invalid();
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierService.AddTier(request));
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenRequestIsDefault()
        {
            //arrange
            var tierList = new TierList()
            {
                Name = "Test",
                Description = "Test",
            };
            await TierDbContext.AddAsync(tierList);
            await TierDbContext.SaveChangesAsync();

            var request = SingularAddTierRequests.Default();
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierService.AddTier(request));
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenRequestIsNull()
        {
            //arrange
            var tierList = new TierList()
            {
                Name = "Test",
                Description = "Test",
            };
            await TierDbContext.AddAsync(tierList);
            await TierDbContext.SaveChangesAsync();

            var request = SingularAddTierRequests.Null();
            //act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await tierService.AddTier(request));
        }
    }
}
