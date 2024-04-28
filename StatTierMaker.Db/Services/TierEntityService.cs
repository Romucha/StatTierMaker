using AutoMapper;
using Microsoft.Extensions.Logging;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.DTO.Requests.Entities;
using StatTierMaker.Db.DTO.Responses.Entities;
using StatTierMaker.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Services
{
    public class TierEntityService : BaseService
    {
        private readonly ILogger<TierEntityService> logger;

        public TierEntityService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TierEntityService> logger) : base(unitOfWork, mapper)
        {
            this.logger = logger;
        }

        public async Task<GetTierEntitiesResponses> GetTierEntities(GetTierEntitiesRequest getTierEntitiesRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Getting tier entities...");
                var tierEntities = await UnitOfWork.TierEntityRepository.GetAllAsync(cancellationToken);
                return new GetTierEntitiesResponses
                {
                    Entities = tierEntities.Select(Mapper.Map<GetTierEntitiesResponse>)
                };
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

        public async Task<GetTierEntityResponse> GetTierEntity(GetTierEntityRequest getTierEntityRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Getting tier entity...");
                var id = getTierEntityRequest.Id;
                var tierEntity = await UnitOfWork.TierEntityRepository.GetAsync(id, cancellationToken);
                return Mapper.Map<GetTierEntityResponse>(tierEntity);
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

        public async Task AddTierEntity(AddTierEntityRequest addTierEntityRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Adding tier entity...");
                var tierEntity = Mapper.Map<TierEntity>(addTierEntityRequest);
                await UnitOfWork.TierEntityRepository.AddAsync(tierEntity, cancellationToken);
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

        public async Task DeleteTierEntity(DeleteTierEntityRequest deleteTierEntityRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Deleting tier entity...");
                var tierEntity = Mapper.Map<TierEntity>(deleteTierEntityRequest);
                await UnitOfWork.TierEntityRepository.DeleteAsync(deleteTierEntityRequest.Id, cancellationToken);
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

        public async Task UpdateTierEntity(UpdateTierEntityRequest updateTierEntityRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Updating tier entity...");
                var tierEntity = Mapper.Map<TierEntity>(updateTierEntityRequest);
                await UnitOfWork.TierEntityRepository.UpdateAsync(tierEntity, cancellationToken);
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
