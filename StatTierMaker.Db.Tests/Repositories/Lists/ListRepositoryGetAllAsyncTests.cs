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
        public async Task GetAllAsync_Normal()
        {
            //arrange
            var tierLists = TierListCollections.Normal();
            await TierDbContext.AddRangeAsync(tierLists);
            await TierDbContext.SaveChangesAsync();
            //act
            var lists = await Repository.GetAllAsync();
            //assert
            Assert.NotNull(lists);
            Assert.NotEmpty(lists);
        }
    }
}
