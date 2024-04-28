using AutoMapper;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.DTO.Requests.Entities;
using StatTierMaker.Db.DTO.Requests.Lists;
using StatTierMaker.Db.DTO.Requests.Parameters;
using StatTierMaker.Db.DTO.Requests.Tiers;
using StatTierMaker.Db.DTO.Responses.Entities;
using StatTierMaker.Db.DTO.Responses.Lists;
using StatTierMaker.Db.DTO.Responses.Parameters;
using StatTierMaker.Db.DTO.Responses.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Mapping
{
    public class TierMapperProfile : Profile
    {
        public TierMapperProfile() 
        {
            //lists
            CreateMap<TierList, AddTierListResponse>().ReverseMap();
            CreateMap<TierList, DeleteTierListResponse>().ReverseMap();
            CreateMap<TierList, GetTierListResponse>().ReverseMap();
            CreateMap<TierList, GetTierListsResponse>().ReverseMap();
            CreateMap<TierList, UpdateTierListResponse>().ReverseMap();

            CreateMap<TierList, AddTierListRequest>().ReverseMap();
            CreateMap<TierList, GetTierListRequest>().ReverseMap();
            CreateMap<TierList, GetTierListsRequest>().ReverseMap();
            CreateMap<TierList, DeleteTierListRequest>().ReverseMap();
            CreateMap<TierList, UpdateTierListRequest>().ReverseMap();

            //tiers
            CreateMap<Tier, AddTierResponse>().ReverseMap();
            CreateMap<Tier, DeleteTierResponse>().ReverseMap();
            CreateMap<Tier, GetTierResponse>().ReverseMap();
            CreateMap<Tier, GetTiersResponse>().ReverseMap();
            CreateMap<Tier, UpdateTierResponse>().ReverseMap();

            CreateMap<Tier, AddTierRequest>().ReverseMap();
            CreateMap<Tier, GetTierRequest>().ReverseMap();
            CreateMap<Tier, GetTiersRequest>().ReverseMap();
            CreateMap<Tier, DeleteTierRequest>().ReverseMap();
            CreateMap<Tier, UpdateTierRequest>().ReverseMap();

            //entities
            CreateMap<TierEntity, AddTierEntityResponse>().ReverseMap();
            CreateMap<TierEntity, DeleteTierEntityResponse>().ReverseMap();
            CreateMap<TierEntity, GetTierEntityResponse>().ReverseMap();
            CreateMap<TierEntity, GetTierEntitiesResponse>().ReverseMap();
            CreateMap<TierEntity, UpdateTierEntityResponse>().ReverseMap();

            CreateMap<TierEntity, AddTierEntityRequest>().ReverseMap();
            CreateMap<TierEntity, GetTierEntityRequest>().ReverseMap();
            CreateMap<TierEntity, GetTierEntitiesRequest>().ReverseMap();
            CreateMap<TierEntity, DeleteTierEntityRequest>().ReverseMap();
            CreateMap<TierEntity, UpdateTierEntityRequest>().ReverseMap();

            //parameters
            CreateMap<TierParameter, AddTierParameterResponse>().ReverseMap();
            CreateMap<TierParameter, DeleteTierParameterResponse>().ReverseMap();
            CreateMap<TierParameter, GetTierParameterResponse>().ReverseMap();
            CreateMap<TierParameter, GetTierParametersResponse>().ReverseMap();
            CreateMap<TierParameter, UpdateTierParameterResponse>().ReverseMap();

            CreateMap<TierParameter, AddTierParameterRequest>().ReverseMap();
            CreateMap<TierParameter, GetTierParameterRequest>().ReverseMap();
            CreateMap<TierParameter, GetTierParametersRequest>().ReverseMap();
            CreateMap<TierParameter, DeleteTierParameterRequest>().ReverseMap();
            CreateMap<TierParameter, UpdateTierParameterRequest>().ReverseMap();
        }
    }
}
