using AutoMapper;
using Microsoft.Extensions.Logging;
using StatTierMaker.API.Tiers;
using StatTierMaker.API.Validation;
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

        public TierParameterService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TierParameterService> logger, IValidator validator) : base(unitOfWork, mapper, validator)
        {
            this.logger = logger;
        }

        public async Task<GetTierParameterResponse> GetTierParameter(GetTierParameterRequest getTierParameterRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Getting tier parameter...");
                var request = await Validator.ValidateAsync(getTierParameterRequest, cancellationToken);

                var tierParameter = await UnitOfWork.TierParameterRepository.GetAsync(request.Id, cancellationToken);

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
                var request = await Validator.ValidateAsync(getTierParametersRequest, cancellationToken);

                var tierParameters = await UnitOfWork.TierParameterRepository.GetAllAsync(request.PageSize, request.PageNumber, cancellationToken);

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
                var request= await Validator.ValidateAsync(addTierParameterRequest, cancellationToken);

                var parameter = Mapper.Map<TierParameter>(request);
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

        public async Task<DeleteTierParameterResponse> DeleteTierParameter(DeleteTierParameterRequest deleteTierParameterRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Deleting tier parameter...");
                var request = await Validator.ValidateAsync(deleteTierParameterRequest, cancellationToken);

                await UnitOfWork.TierParameterRepository.DeleteAsync(request.Id, cancellationToken);

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

        public async Task<UpdateTierParameterResponse> UpdateTierParameter(UpdateTierParameterRequest updateTierParameterRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Updating tier parameter...");
                var request = await Validator.ValidateAsync(updateTierParameterRequest, cancellationToken);

                var parameter = Mapper.Map<TierParameter>(request);
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
