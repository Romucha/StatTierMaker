using StatTierMaker.Tests.Common.TestData.Entities;
using StatTierMaker.Tests.Common.TestData.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Repositories.Lists
{
    public partial class ListRepositoryTests
    {
        [Fact]
        public async Task DeleteAsync_Normal()
        {
            //arrange
            var originalTierList = SingularLists.Normal();
            await TierDbContext.TierLists.AddAsync(originalTierList);
            await TierDbContext.SaveChangesAsync();
            var id = TierDbContext.TierLists.Entry(originalTierList).Entity.Id;
            //act
            await Repository.DeleteAsync(id);
            //assert
            Assert.Null(await TierDbContext.TierLists.FindAsync(id));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task DeleteAsync_ThrowsError_WhenIdIsInvalid(int id)
        {
            //arrange
            var originalTierList = SingularLists.Normal();
            await TierDbContext.TierLists.AddAsync(originalTierList);
            await TierDbContext.SaveChangesAsync();
            //act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await Repository.DeleteAsync(id));
            Assert.NotNull(TierDbContext.TierLists.Entry(originalTierList).Entity);
        }
    }
}
