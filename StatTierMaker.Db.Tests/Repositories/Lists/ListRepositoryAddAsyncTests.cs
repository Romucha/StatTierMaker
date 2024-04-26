using StatTierMaker.Tests.Common.TestAPIData.Entities;
using StatTierMaker.Tests.Common.TestAPIData.Lists;
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
        public async Task AddAsync_Normal()
        {
            //arrange
            var tierList = SingularLists.Normal();
            //act
            await Repository.AddAsync(tierList);
            //assert
            Assert.NotEmpty(TierDbContext.TierLists);
            Assert.NotEmpty(TierDbContext.Tiers);
            Assert.NotEmpty(TierDbContext.TierEntities);
            Assert.NotEmpty(TierDbContext.TierParameters);
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenTierListIsInvalid()
        {
            //arrange
            var tierList = SingularLists.Invalid();
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await Repository.AddAsync(tierList));
            Assert.Empty(TierDbContext.TierLists);
            Assert.Empty(TierDbContext.Tiers);
            Assert.Empty(TierDbContext.TierEntities);
            Assert.Empty(TierDbContext.TierParameters);
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenTierListIsDefault()
        {
            //arrange
            var tierList = SingularLists.Default();
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await Repository.AddAsync(tierList));
            Assert.Empty(TierDbContext.TierLists);
            Assert.Empty(TierDbContext.Tiers);
            Assert.Empty(TierDbContext.TierEntities);
            Assert.Empty(TierDbContext.TierParameters);
        }


        [Fact]
        public async Task AddAsync_ThrowsException_WhenEntityIsNull()
        {
            //arrange
            var tierList = SingularLists.Null();
            //act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await Repository.AddAsync(tierList));
            Assert.Empty(TierDbContext.TierLists);
            Assert.Empty(TierDbContext.Tiers);
            Assert.Empty(TierDbContext.TierEntities);
            Assert.Empty(TierDbContext.TierParameters);
        }
    }
}
