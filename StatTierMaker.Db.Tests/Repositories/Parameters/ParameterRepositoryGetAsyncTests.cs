using Microsoft.EntityFrameworkCore;
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
        public async Task GetAsync_Normal()
        {
            //arrange
            var tierParameter = SingularParameters.Normal();
            await TierDbContext.AddRangeAsync(tierParameter);
            await TierDbContext.SaveChangesAsync();
            var id = TierDbContext.TierParameters.Entry(tierParameter).Entity.Id;
            //act
            var result = await Repository.GetAsync(id);
            //assert
            Assert.NotNull(result);
            Assert.Equal(tierParameter, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task GetAsync_ReturnsNull_WhenIdIsInvalid(int id)
        {

            //arrange
            var tierParameter = SingularParameters.Normal();
            await TierDbContext.AddRangeAsync(tierParameter);
            await TierDbContext.SaveChangesAsync();
            //act
            var result = await Repository.GetAsync(id);
            //assert
            Assert.Null(result);
        }
    }
}
