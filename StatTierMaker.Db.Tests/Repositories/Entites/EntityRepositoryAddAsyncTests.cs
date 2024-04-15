using StatTierMaker.Tests.Common.TestData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Repositories.Entites
{
    public partial class EntityRepositoryTests
    {
        [Fact]
        public async Task AddAsync_Normal()
        {
            //arrange
            var entity = SingularEntities.Normal();
            //act
            await Repository.AddAsync(entity);
            //assert
            Assert.NotEmpty(TierDbContext.TierEntities);
            Assert.NotEmpty(TierDbContext.TierParameters);
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenEntityIsInvalid()
        {
            //arrange
            var entity = SingularEntities.Invalid();
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await Repository.AddAsync(entity));
            Assert.Empty(TierDbContext.TierEntities);
            Assert.Empty(TierDbContext.TierParameters);
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenEntityIsDefault()
        {
            //arrange
            var entity = SingularEntities.Default();
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await Repository.AddAsync(entity));
            Assert.Empty(TierDbContext.TierEntities);
            Assert.Empty(TierDbContext.TierParameters);
        }


        [Fact]
        public async Task AddAsync_ThrowsException_WhenEntityIsNull()
        {
            //arrange
            var entity = SingularEntities.Null();
            //act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await Repository.AddAsync(entity));
            Assert.Empty(TierDbContext.TierEntities);
            Assert.Empty(TierDbContext.TierParameters);
        }
    }
}
