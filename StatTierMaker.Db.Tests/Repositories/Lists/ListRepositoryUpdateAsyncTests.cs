using StatTierMaker.Db.Repositories;
using StatTierMaker.Tests.Common.TestAPIData.Entities;
using StatTierMaker.Tests.Common.TestAPIData.Lists;
using StatTierMaker.Tests.Common.TestAPIData.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Repositories.Lists
{
    public partial class ListRepositoryTests
    {
        [Fact]
        public async Task UpdateAsync_Normal()
        {
            //arrange
            string updatedName = "Updated name";
            var entityToAdd = SingularEntities.Normal();

            var tierList = SingularLists.Normal();
            await TierDbContext.TierLists.AddAsync(tierList);
            await TierDbContext.SaveChangesAsync();
            //act
            tierList.Name = updatedName;
            tierList.Entities.Add(entityToAdd);
            await Repository.UpdateAsync(tierList);
            var updatedList = TierDbContext.TierLists.Entry(tierList).Entity;
            //assert
            Assert.NotNull(updatedList);
            Assert.Equal(updatedName, updatedList.Name);
            Assert.True(updatedList.Entities.Contains(entityToAdd));
        }

        [Fact]
        public async Task UpdateAsync_Normal_NoActions()
        {
            //arrange
            var originalTierList = SingularLists.Normal();
            await TierDbContext.TierLists.AddAsync(originalTierList);
            await TierDbContext.SaveChangesAsync();
            //act
            await Repository.UpdateAsync(originalTierList);
            var updatedEntity = TierDbContext.TierLists.Entry(originalTierList).Entity;
            //assert
            Assert.NotNull(updatedEntity);
        }

        [Fact]
        public async Task UpdateAsync_Normal_WhenAllEntitiesAreCleared()
        {
            //arrange
            var originalTierList = SingularLists.Normal();
            await TierDbContext.TierLists.AddAsync(originalTierList);
            await TierDbContext.SaveChangesAsync();
            //act
            originalTierList.Entities.Clear();
            await Repository.UpdateAsync(originalTierList);
            var updatedEntity = TierDbContext.TierLists.Entry(originalTierList).Entity;
            //assert
            Assert.NotNull(updatedEntity);
            Assert.NotNull(updatedEntity.Entities);
            Assert.Empty(updatedEntity.Entities);
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenUpdatedParametersAreInvalid()
        {
            //arrange
            string updatedName = "";
            var originalTierList = SingularLists.Normal();
            await TierDbContext.TierLists.AddAsync(originalTierList);
            await TierDbContext.SaveChangesAsync();
            //act && assert
            originalTierList.Name = updatedName;
            await Assert.ThrowsAsync<ValidationException>(async () => await Repository.UpdateAsync(originalTierList));
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenTierListIsSetToNull()
        {
            //arrange
            var originalTierList = SingularLists.Normal();
            await TierDbContext.TierLists.AddAsync(originalTierList);
            await TierDbContext.SaveChangesAsync();
            //act && assert
            originalTierList = null;
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await Repository.UpdateAsync(originalTierList));
        }
    }
}
