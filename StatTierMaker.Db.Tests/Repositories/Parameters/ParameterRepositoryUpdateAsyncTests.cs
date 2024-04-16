using Microsoft.EntityFrameworkCore;
using StatTierMaker.Tests.Common.TestData.Entities;
using StatTierMaker.Tests.Common.TestData.Lists;
using StatTierMaker.Tests.Common.TestData.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Repositories.Parameters
{
    public partial class ParameterRepositoryTests
    {
        [Fact]
        public async Task UpdateAsync_Normal()
        {
            //arrange
            string updatedName = "Updated name";
            var parameter = SingularParameters.Normal();
            var entities = EntityCollections.Normal();

            await TierDbContext.TierParameters.AddAsync(parameter);
            await TierDbContext.TierEntities.AddRangeAsync(entities);
            await TierDbContext.SaveChangesAsync();
            //act
            parameter.Name = updatedName;
            parameter.TierEntityId = TierDbContext.TierEntities.First().Id;
            await Repository.UpdateAsync(parameter);
            var updatedParameter = TierDbContext.TierParameters.Entry(parameter).Entity;
            //assert
            Assert.NotNull(updatedParameter);
            Assert.Equal(updatedName, updatedParameter.Name);
            Assert.Equal(TierDbContext.TierEntities.First(), updatedParameter.TierEntity);
        }

        [Fact]
        public async Task UpdateAsync_Normal_NoActions()
        {
            //arrange
            var parameter = SingularParameters.Normal();

            await TierDbContext.TierParameters.AddAsync(parameter);
            await TierDbContext.SaveChangesAsync();
            //act
            await Repository.UpdateAsync(parameter);
            var updatedParameter = TierDbContext.TierParameters.Entry(parameter).Entity;
            //assert
            Assert.NotNull(updatedParameter);
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenParameterIsSetToNull()
        {
            //arrange
            var parameter = SingularParameters.Normal();

            await TierDbContext.TierParameters.AddAsync(parameter);
            await TierDbContext.SaveChangesAsync();
            //act & assert
            parameter = null;
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await Repository.UpdateAsync(parameter));
        }


        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenAllParametersAreInvalid()
        {
            //arrange
            string updatedName = "";
            var parameter = SingularParameters.Normal();
            var entities = EntityCollections.Normal();

            await TierDbContext.TierParameters.AddAsync(parameter);
            await TierDbContext.TierEntities.AddRangeAsync(entities);
            await TierDbContext.SaveChangesAsync();
            //act & assert
            parameter.Name = updatedName;
            parameter.TierEntityId = TierDbContext.TierEntities.First().Id;
            await Assert.ThrowsAsync<ValidationException>(async () => await Repository.UpdateAsync(parameter));
        }
    }
}
