using AutoMapper;
using Microsoft.Extensions.Logging;
using StatTierMaker.API.Tiers;
using StatTierMaker.API.Validation;
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

        public TierEntityService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TierEntityService> logger, IValidator validator) : base(unitOfWork, mapper, validator)
        {
            this.logger = logger;
        }

        public async Task<GetTierEntitiesResponses> GetTierEntities(GetTierEntitiesRequest getTierEntitiesRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Getting tier entities...");
                var request = await Validator.ValidateAsync(getTierEntitiesRequest, cancellationToken);

                var tierEntities = await UnitOfWork.TierEntityRepository.GetAllAsync(request.PageSize, request.PageNumber, cancellationToken);

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
                var request= await Validator.ValidateAsync(getTierEntityRequest, cancellationToken);

                var id = request.Id;
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

        public async Task<AddTierEntityResponse> AddTierEntity(AddTierEntityRequest addTierEntityRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Adding tier entity...");
                var request = await Validator.ValidateAsync(addTierEntityRequest, cancellationToken);

                var tierEntity = Mapper.Map<TierEntity>(request);
                await UnitOfWork.TierEntityRepository.AddAsync(tierEntity, cancellationToken);

                return new AddTierEntityResponse()
                {
                    Id = tierEntity.Id
                };
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

        public async Task<DeleteTierEntityResponse> DeleteTierEntity(DeleteTierEntityRequest deleteTierEntityRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Deleting tier entity...");
                var request = await Validator.ValidateAsync(deleteTierEntityRequest, cancellationToken);

                await UnitOfWork.TierEntityRepository.DeleteAsync(request.Id, cancellationToken);

                return new DeleteTierEntityResponse()
                {
                    Id = request.Id,
                };
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

        public async Task<UpdateTierEntityResponse> UpdateTierEntity(UpdateTierEntityRequest updateTierEntityRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Updating tier entity...");
                var request = await Validator.ValidateAsync(updateTierEntityRequest, cancellationToken);

                var tierEntity = Mapper.Map<TierEntity>(request);
                await UnitOfWork.TierEntityRepository.UpdateAsync(tierEntity, cancellationToken);

                return new UpdateTierEntityResponse()
                {
                    Id = request.Id,
                };
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
