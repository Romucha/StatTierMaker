﻿using Microsoft.EntityFrameworkCore;
using StatTierMaker.Db.Repositories;
using StatTierMaker.Db.Services;
using StatTierMaker.Tests.Common.TestAPIData.Entities;
using StatTierMaker.Tests.Common.TestAPIData.Tiers;
using StatTierMaker.Tests.Common.TestDbData.Entities.Get;
using StatTierMaker.Tests.Common.TestDbData.Entities.Update;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Services.Entities
{
    public partial class TierEntityServiceTests
    {
        [Fact]
        public async Task UpdateAsync_Normal()
        {
            //arrange
            var tier = SingularTiers.Normal();
            var entity = SingularEntities.Normal();
            await TierDbContext.Tiers.AddAsync(tier);
            entity.TierId = TierDbContext.Tiers.Entry(tier).Entity.Id;
            await TierDbContext.TierEntities.AddAsync(entity);
            var id = TierDbContext.TierEntities.Entry(entity).Entity.Id;
            await TierDbContext.SaveChangesAsync();
            TierDbContext.ChangeTracker.Clear();
            var request = SingularUpdateTierEntitiyRequests.Normal(id, entity.TierId);
            //act
            var response = await tierEntityService.UpdateTierEntity(request);
            //assert
            var updatedEntity = await TierDbContext.TierEntities.FindAsync(id);
            Assert.NotNull(updatedEntity);
            Assert.Equal(id, updatedEntity.Id);
            Assert.Equal(request.Name, updatedEntity.Name);
            Assert.Equal(request.Description, updatedEntity.Description);
            Assert.Equal(request.TierId, updatedEntity.TierId);
            Assert.Equal(request.TierEntityParameters.Count, updatedEntity.TierEntityParameters.Count);

            Assert.NotNull(response);
            Assert.NotEqual(0, response.Id);
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenRequestIsInvalid()
        {
            //arrange
            var tier = SingularTiers.Normal();
            var entity = SingularEntities.Normal();
            await TierDbContext.Tiers.AddAsync(tier);
            entity.TierId = TierDbContext.Tiers.Entry(tier).Entity.Id;
            await TierDbContext.TierEntities.AddAsync(entity);
            var id = TierDbContext.TierEntities.Entry(entity).Entity.Id;
            await TierDbContext.SaveChangesAsync();
            TierDbContext.ChangeTracker.Clear();
            var request = SingularUpdateTierEntitiyRequests.Invalid();
            //act
            await Assert.ThrowsAsync<ValidationException>(async () => await tierEntityService.UpdateTierEntity(request));
            //assert
            var updatedEntity = await TierDbContext.TierEntities.FirstOrDefaultAsync(c => c.Id == id);
            Assert.NotNull(updatedEntity);
            Assert.Equal(id, updatedEntity.Id);
            Assert.Equal(entity.Name, updatedEntity.Name);
            Assert.Equal(entity.Description, updatedEntity.Description);
            Assert.Equal(entity.TierId, updatedEntity.TierId);
            /*
             * TO-DO: figure out why lists are rest to null
             */
            //Assert.Equal(entity.TierEntityParameters.Count, updatedEntity.TierEntityParameters.Count);
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenRequestIsDefault()
        {
            //arrange
            var tier = SingularTiers.Normal();
            var entity = SingularEntities.Normal();
            await TierDbContext.Tiers.AddAsync(tier);
            entity.TierId = TierDbContext.Tiers.Entry(tier).Entity.Id;
            await TierDbContext.TierEntities.AddAsync(entity);
            var id = TierDbContext.TierEntities.Entry(entity).Entity.Id;
            await TierDbContext.SaveChangesAsync();
            TierDbContext.ChangeTracker.Clear();
            var request = SingularUpdateTierEntitiyRequests.Default();
            //act
            await Assert.ThrowsAsync<ValidationException>(async () => await tierEntityService.UpdateTierEntity(request));
            //assert
            var updatedEntity = await TierDbContext.TierEntities.FindAsync(id);
            Assert.NotNull(updatedEntity);
            Assert.Equal(id, updatedEntity.Id);
            Assert.Equal(entity.Name, updatedEntity.Name);
            Assert.Equal(entity.Description, updatedEntity.Description);
            Assert.Equal(entity.TierId, updatedEntity.TierId);
            //Assert.Equal(entity.TierEntityParameters.Count, updatedEntity.TierEntityParameters.Count);
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenRequestIsNull()
        {
            //arrange
            var tier = SingularTiers.Normal();
            var entity = SingularEntities.Normal();
            await TierDbContext.Tiers.AddAsync(tier);
            entity.TierId = TierDbContext.Tiers.Entry(tier).Entity.Id;
            await TierDbContext.TierEntities.AddAsync(entity);
            var id = TierDbContext.TierEntities.Entry(entity).Entity.Id;
            await TierDbContext.SaveChangesAsync();
            TierDbContext.ChangeTracker.Clear();
            var request = SingularUpdateTierEntitiyRequests.Null();
            //act
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await tierEntityService.UpdateTierEntity(request));
            //assert
            var updatedEntity = TierDbContext.TierEntities.FirstOrDefault(c => c.Id == id);
            Assert.NotNull(updatedEntity);
            Assert.Equal(id, updatedEntity.Id);
            Assert.Equal(entity.Name, updatedEntity.Name);
            Assert.Equal(entity.Description, updatedEntity.Description);
            Assert.Equal(entity.TierId, updatedEntity.TierId);
            //Assert.Equal(entity.TierEntityParameters.Count, updatedEntity.TierEntityParameters.Count);
        }
    }
}
