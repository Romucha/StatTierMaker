using Microsoft.EntityFrameworkCore;
using StatTierMaker.Tests.Common.TestAPIData.Entities;
using StatTierMaker.Tests.Common.TestAPIData.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Repositories.Entites
{
    public partial class EntityRepositoryTests
    {
        [Fact]
        public async Task UpdateAsync_Normal()
        {
            //arrange
            string updatedName = "Updated name";
            var parameterToAdd = SingularParameters.Normal();
            var originalTierEntity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(originalTierEntity);
            await TierDbContext.SaveChangesAsync();
            //act
            originalTierEntity.Name = updatedName;
            originalTierEntity.TierEntityParameters.Add(parameterToAdd);
            await Repository.UpdateAsync(originalTierEntity);
            var updatedEntity = TierDbContext.TierEntities.Entry(originalTierEntity).Entity;
            //assert
            Assert.NotNull(updatedEntity);
            Assert.Equal(updatedName, updatedEntity.Name);
            Assert.True(updatedEntity.TierEntityParameters.Contains(parameterToAdd));
        }

        [Fact]
        public async Task UpdateAsync_Normal_NoActions()
        {
            //arrange
            var originalTierEntity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(originalTierEntity);
            await TierDbContext.SaveChangesAsync();
            //act
            await Repository.UpdateAsync(originalTierEntity);
            var updatedEntity = TierDbContext.TierEntities.Entry(originalTierEntity).Entity;
            //assert
            Assert.NotNull(updatedEntity);
        }

        [Fact]
        public async Task UpdateAsync_Normal_WhenAllParametersAreCleared()
        {
            //arrange
            var originalTierEntity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(originalTierEntity);
            await TierDbContext.SaveChangesAsync();
            //act
            originalTierEntity.TierEntityParameters.Clear();
            await Repository.UpdateAsync(originalTierEntity);
            var updatedEntity = TierDbContext.TierEntities.Entry(originalTierEntity).Entity;
            //assert
            Assert.NotNull(updatedEntity);
            Assert.NotNull(updatedEntity.TierEntityParameters);
            Assert.Empty(updatedEntity.TierEntityParameters);
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenUpdatedParametersAreInvalid()
        {
            //arrange
            string updatedName = "";
            var originalTierEntity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(originalTierEntity);
            await TierDbContext.SaveChangesAsync();
            //act && assert
            originalTierEntity.Name = updatedName;
            await Assert.ThrowsAsync<ValidationException>(async () => await Repository.UpdateAsync(originalTierEntity));
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenEntityIsSetToNull()
        {
            //arrange
            var originalTierEntity = SingularEntities.Normal();
            await TierDbContext.TierEntities.AddAsync(originalTierEntity);
            await TierDbContext.SaveChangesAsync();
            //act && assert
            originalTierEntity = null;
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await Repository.UpdateAsync(originalTierEntity));
        }
    }
}
