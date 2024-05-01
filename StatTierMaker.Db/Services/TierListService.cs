using AutoMapper;
using Microsoft.Extensions.Logging;
using StatTierMaker.API.Tiers;
using StatTierMaker.API.Validation;
using StatTierMaker.Db.DTO.Requests.Lists;
using StatTierMaker.Db.DTO.Responses.Entities;
using StatTierMaker.Db.DTO.Responses.Lists;
using StatTierMaker.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Services
{
    public class TierListService : BaseService
    {
        private readonly ILogger<TierListService> logger;

        public TierListService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TierListService> logger, IValidator validator) : base(unitOfWork, mapper, validator)
        {
            this.logger = logger;
        }

        public async Task<GetTierListsResponses> GetTierLists(GetTierListsRequest getTierListsRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Getting tier lists...");
                var request = await Validator.ValidateAsync(getTierListsRequest, cancellationToken);

                var lists = await UnitOfWork.TierListRepository.GetAllAsync(request.PageSize, request.PageNumber, cancellationToken);

                return new GetTierListsResponses
                {
                    TierLists = lists.Select(Mapper.Map<GetTierListsResponse>)
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

        public async Task<GetTierListResponse> GetTierList(GetTierListRequest getTierListRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Getting tier list...");
                var request = await Validator.ValidateAsync(getTierListRequest, cancellationToken);

                var list = await UnitOfWork.TierListRepository.GetAsync(request.Id, cancellationToken);

                return Mapper.Map<GetTierListResponse>(list);
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

        public async Task<AddTierListResponse> AddTierList(AddTierListRequest addTierListRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Adding tier list...");
                var request = await Validator.ValidateAsync(addTierListRequest, cancellationToken);

                var list = Mapper.Map<TierList>(request);
                await UnitOfWork.TierListRepository.AddAsync(list, cancellationToken);

                return new AddTierListResponse()
                {
                    Id = list.Id,
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

        public async Task<DeleteTierListResponse> DeleteTierList(DeleteTierListRequest deleteTierListRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Deleting tier list...");
                var request = await Validator.ValidateAsync(deleteTierListRequest, cancellationToken);

                await UnitOfWork.TierListRepository.DeleteAsync(request.Id, cancellationToken);

                return new DeleteTierListResponse
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

        public async Task<UpdateTierListResponse> UpdateTierList(UpdateTierListRequest updateTierListRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Updating tier list...");
                var request = await Validator.ValidateAsync(updateTierListRequest, cancellationToken);

                var list = Mapper.Map<TierList>(request);
                await UnitOfWork.TierListRepository.UpdateAsync(list, cancellationToken);

                return Mapper.Map<UpdateTierListResponse>(list);
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
