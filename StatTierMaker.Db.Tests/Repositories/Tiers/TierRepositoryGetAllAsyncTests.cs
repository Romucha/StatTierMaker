using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.Repositories;
using StatTierMaker.Tests.Common.TestAPIData.Tiers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Repositories.Tiers
{
    public partial class TierRepositoryTests
    {
        [Fact]
        public async Task GetAllAsync_Normal()
        {
            //arrange
            var tiers = TierCollections.Normal();
            await TierDbContext.Tiers.AddRangeAsync(tiers);
            await TierDbContext.SaveChangesAsync();
            //act
            var result = await Repository.GetAllAsync();
            //assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
