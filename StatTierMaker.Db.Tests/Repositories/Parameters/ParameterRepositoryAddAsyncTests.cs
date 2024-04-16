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
        public async Task AddAsync_Normal()
        {
            //arrange
            var tierParameter = SingularParameters.Normal();
            //act
            await Repository.AddAsync(tierParameter);
            var addedParameter = TierDbContext.TierParameters.Entry(tierParameter).Entity;
            //assert
            Assert.NotNull(addedParameter);
            Assert.True(await TierDbContext.TierParameters.ContainsAsync(tierParameter));
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenParameterIsInvalid()
        {
            //arrange
            var tierParameter = SingularParameters.Invalid();
            //act
            await Assert.ThrowsAsync<ValidationException>(async () => await Repository.AddAsync(tierParameter));
            var addedParameter = TierDbContext.TierParameters.Entry(tierParameter).Entity;
            //assert
            Assert.False(await TierDbContext.TierParameters.ContainsAsync(tierParameter));
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenParameterIsDefault()
        {
            //arrange
            var tierParameter = SingularParameters.Default();
            //act
            await Assert.ThrowsAsync<ValidationException>(async () => await Repository.AddAsync(tierParameter));
            //assert
            Assert.False(await TierDbContext.TierParameters.ContainsAsync(tierParameter));
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenParameterIsNull()
        {
            //arrange
            var tierParameter = SingularParameters.Null();
            //act
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await Repository.AddAsync(tierParameter));
            //assert
            Assert.False(await TierDbContext.TierParameters.ContainsAsync(tierParameter));
        }
    }
}
