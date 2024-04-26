using StatTierMaker.Tests.Common.TestAPIData.Lists;
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
        public async Task GetAsync_Normal()
        {
            //arrange
            var tierList = SingularLists.Normal();
            await TierDbContext.TierLists.AddAsync(tierList);
            await TierDbContext.SaveChangesAsync();
            //act
            var id = TierDbContext.TierLists.Entry(tierList).Entity.Id;
            var result = await Repository.GetAsync(id);
            //assert
            Assert.NotNull(result);
            Assert.Equal(tierList, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task GetAsync_ReturnsNull_WhenIdIsInvalid(int id)
        {
            //arrange
            var tierList = SingularLists.Normal();
            await TierDbContext.TierLists.AddAsync(tierList);
            await TierDbContext.SaveChangesAsync();
            //act
            var result = await Repository.GetAsync(id);
            //assert
            Assert.Null(result);
        }
    }
}
