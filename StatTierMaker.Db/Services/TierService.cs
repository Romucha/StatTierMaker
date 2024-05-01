using AutoMapper;
using Microsoft.Extensions.Logging;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.DTO.Requests.Parameters;
using StatTierMaker.Db.DTO.Requests.Tiers;
using StatTierMaker.Db.DTO.Responses.Parameters;
using StatTierMaker.Db.DTO.Responses.Tiers;
using StatTierMaker.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Services
{
    public class TierService : BaseService
    {
        private readonly ILogger<TierService> logger;

        public TierService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TierService> logger) : base(unitOfWork, mapper)
        {
            this.logger = logger;
        }

        public async Task<GetTiersResponses> GetTiers(GetTiersRequest getTiersRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Getting tiers...");
                var tiers = await UnitOfWork.TierRepository.GetAllAsync(cancellationToken);
                return new GetTiersResponses
                {
                    Tiers = tiers.Select(c => Mapper.Map<GetTiersResponse>(c))
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

        public async Task<GetTierResponse> GetTier(GetTierRequest getTierRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Getting tier...");
                var tier = await UnitOfWork.TierRepository.GetAsync(getTierRequest.Id, cancellationToken);
                return Mapper.Map<GetTierResponse>(tier);
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

        public async Task<AddTierResponse> AddTier(AddTierRequest addTierRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Adding tier...");
                var tier = Mapper.Map<Tier>(addTierRequest);
                await UnitOfWork.TierRepository.AddAsync(tier, cancellationToken);
                return new AddTierResponse()
                {
                    Id = tier.Id,
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

        public async Task<DeleteTierResponse> DeleteTier(DeleteTierRequest deleteTierRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Deleting tier...");
                await UnitOfWork.TierRepository.DeleteAsync(deleteTierRequest.Id, cancellationToken);
                return new DeleteTierResponse
                {
                    Id = deleteTierRequest.Id,
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

        public async Task<UpdateTierResponse> UpdateTier(UpdateTierRequest updateTierRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Updating tier...");
                var tier = Mapper.Map<Tier>(updateTierRequest);
                await UnitOfWork.TierRepository.UpdateAsync(tier, cancellationToken);
                return Mapper.Map<UpdateTierResponse>(tier);
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
