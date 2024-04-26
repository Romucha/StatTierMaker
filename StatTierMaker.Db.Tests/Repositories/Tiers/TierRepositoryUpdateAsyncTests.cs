using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.Repositories;
using StatTierMaker.Tests.Common.TestAPIData.Entities;
using StatTierMaker.Tests.Common.TestAPIData.Parameters;
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
        public async Task UpdateAsync_Normal()
        {
            //arrange
            var tier = SingularTiers.Normal();
            await TierDbContext.Tiers.AddAsync(tier);
            await TierDbContext.SaveChangesAsync();
            var updatedName = "Updated name";
            var entityToAdd = SingularEntities.Normal();
            //act
            tier.Name = updatedName;
            tier.Entities.Add(entityToAdd);
            await Repository.UpdateAsync(tier);
            //assert
            var updatedTier = TierDbContext.Tiers.Entry(tier).Entity;
            Assert.NotNull(updatedTier);
            Assert.Equal(updatedName, updatedTier.Name);
            Assert.True(updatedTier.Entities.Contains(TierDbContext.TierEntities.Entry(entityToAdd).Entity));
        }

        [Fact]
        public async Task UpdateAsync_Normal_NoActions()
        {
            //arrange
            var tier = SingularTiers.Normal();
            await TierDbContext.Tiers.AddAsync(tier);
            await TierDbContext.SaveChangesAsync();
            //act
            await Repository.UpdateAsync(tier);
            //assert
            var updatedTier = TierDbContext.Tiers.Entry(tier).Entity;
            Assert.NotNull(updatedTier);
        }
        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenTierIsSetToNull()
        {
            //arrange
            var tier = SingularTiers.Normal();
            await TierDbContext.Tiers.AddAsync(tier);
            await TierDbContext.SaveChangesAsync();
            //act & assert
            tier = null;
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await Repository.UpdateAsync(tier));
        }


        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenAllParametersAreInvalid()
        {
            //arrange
            string updatedName = "";
            var tier = SingularTiers.Normal();
            await TierDbContext.Tiers.AddAsync(tier);
            await TierDbContext.SaveChangesAsync();
            //act & assert
            tier.Name = updatedName;
            await Assert.ThrowsAsync<ValidationException>(async () => await Repository.UpdateAsync(tier));
        }
    }
}
