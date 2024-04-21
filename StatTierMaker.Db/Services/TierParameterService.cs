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
    public class TierParameterService : BaseService
    {
        private readonly ILogger<TierParameterService> logger;

        public TierParameterService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TierParameterService> logger) : base(unitOfWork, mapper)
        {
            this.logger = logger;
        }

        public async Task<GetTierParameterResponse> GetTierParameter(GetTierParameterRequest getTierParameterRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Getting tier parameter...");
                var tierParameter = await UnitOfWork.TierParameterRepository.GetAsync(getTierParameterRequest.Id, cancellationToken);
                return Mapper.Map<GetTierParameterResponse>(tierParameter);
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

        public async Task<GetTierParametersResponses> GetTierParameters(GetTierParametersRequest getTierParametersRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Getting tier parameters...");
                var tierParameters = await UnitOfWork.TierParameterRepository.GetAllAsync(cancellationToken);
                return new GetTierParametersResponses()
                {
                    Parameters = tierParameters.Select(Mapper.Map<GetTierParametersResponse>)
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

        public async Task<AddTierParameterResponse> AddTierParameter(AddTierParameterRequest addTierParameterRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Adding tier parameter...");
                var parameter = Mapper.Map<TierParameter>(addTierParameterRequest);
                await UnitOfWork.TierParameterRepository.AddAsync(parameter, cancellationToken);
                return Mapper.Map<AddTierParameterResponse>(parameter);
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

        public async Task<DeleteTierParameterResponse> DeleteTier(DeleteTierParameterRequest deleteTierParameterRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Deleting tier parameter...");
                await UnitOfWork.TierParameterRepository.DeleteAsync(deleteTierParameterRequest.Id, cancellationToken);
                return new DeleteTierParameterResponse()
                {
                    Id = deleteTierParameterRequest.Id
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

        public async Task<UpdateTierParameterResponse> UpdateTier(UpdateTierParameterRequest updateTierParameterRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Updating tier parameter...");
                var parameter = Mapper.Map<TierParameter>(updateTierParameterRequest);
                await UnitOfWork.TierParameterRepository.UpdateAsync(parameter, cancellationToken);
                return Mapper.Map<UpdateTierParameterResponse>(await UnitOfWork.TierParameterRepository.GetAsync(parameter.Id));
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
