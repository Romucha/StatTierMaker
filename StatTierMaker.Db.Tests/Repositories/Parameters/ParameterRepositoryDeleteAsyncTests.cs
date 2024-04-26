using Microsoft.EntityFrameworkCore;
using StatTierMaker.Tests.Common.TestAPIData.Parameters;
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
        public async Task DeleteAsync_Normal()
        {
            //arrange
            var tierParameter = SingularParameters.Normal();
            await TierDbContext.AddAsync(tierParameter);
            await TierDbContext.SaveChangesAsync();
            var id = TierDbContext.TierParameters.Entry(tierParameter).Entity.Id;
            //act
            await Repository.DeleteAsync(id);
            //assert
            Assert.False(await TierDbContext.TierParameters.ContainsAsync(tierParameter));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task DeleteAsync_ThrowsException_WhenIdIsInvalid(int id)
        {
            //arrange
            var tierParameter = SingularParameters.Normal();
            await TierDbContext.AddAsync(tierParameter);
            await TierDbContext.SaveChangesAsync();
            //act
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await Repository.DeleteAsync(id));
            //assert
            Assert.True(await TierDbContext.TierParameters.ContainsAsync(tierParameter));
        }
    }
}
