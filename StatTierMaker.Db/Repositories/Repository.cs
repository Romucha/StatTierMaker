using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TierDbContext tierDbContext;
        private readonly ILogger<Repository<T>> logger;
        private readonly IValidator validator;

        public Repository(TierDbContext tierDbContext, ILogger<Repository<T>> logger, IValidator validator)
        {
            this.tierDbContext = tierDbContext;
            this.logger = logger;
            this.validator = validator;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var validEntity = await validator.ValidateAsync(entity);
                logger.LogInformation($"Adding {entity} to datadase...");
                await tierDbContext.Set<T>().AddAsync(validEntity);
                await tierDbContext.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                logger.LogInformation("Adding done.");
            }
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Deleting entity with id: {id}...");
                var entity = await tierDbContext.Set<T>().FindAsync(id);
                tierDbContext.Set<T>().Remove(entity);
                await tierDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                logger.LogInformation("Deleting done.");
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Getting list of {typeof(T)}...");
                return await tierDbContext.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                logger.LogInformation("Getting done.");
            }
        }

        public async Task<T>? GetAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Getting entity with id: {id}...");
                return await tierDbContext.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                logger.LogInformation("Getting done.");
            }
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Updating entity {entity}...");
                var validEntity = await validator.ValidateAsync(entity);
                tierDbContext.Set<T>().Update(validEntity);
                await tierDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                logger.LogInformation("Updating done.");
            }
        }
    }
}
