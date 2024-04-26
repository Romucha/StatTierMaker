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
        public async Task GetAllAsync_Normal()
        {
            //arrange
            var tierParameters = ParameterCollections.Normal();
            await TierDbContext.AddRangeAsync(tierParameters);
            await TierDbContext.SaveChangesAsync();
            //act
            var result = await Repository.GetAllAsync();
            //assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
