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
        public async Task AddAsync_Normal()
        {
            //arrange
            var tier = SingularTiers.Normal();
            //act
            await Repository.AddAsync(tier);
            //assert
            Assert.NotNull(TierDbContext.Tiers.Entry(tier).Entity);
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenTierIsInvalid()
        {
            //arrange
            var tier = SingularTiers.Invalid();
            //act && assert
            await Assert.ThrowsAsync<ValidationException>(async () => await Repository.AddAsync(tier));
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenTierIsDefault()
        {
            //arrange
            var tier = SingularTiers.Default();
            //act && assert
            await Assert.ThrowsAsync<ValidationException>(async () => await Repository.AddAsync(tier));
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenTierIsNull()
        {
            //arrange
            var tier = SingularTiers.Null();
            //act && assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await Repository.AddAsync(tier));
        }
    }
}
