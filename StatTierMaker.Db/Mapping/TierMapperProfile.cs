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
            CreateMap<TierList, GetTierListResponse>().ReverseMap();
            CreateMap<TierList, AddTierListRequest>().ReverseMap();
            CreateMap<TierList, GetTierListRequest>().ReverseMap();
            CreateMap<TierList, DeleteTierListRequest>().ReverseMap();
            CreateMap<TierList, UpdateTierListRequest>().ReverseMap();

            //tiers
            CreateMap<Tier, GetTierResponse>().ReverseMap();
            CreateMap<Tier, AddTierRequest>().ReverseMap();
            CreateMap<Tier, GetTierRequest>().ReverseMap();
            CreateMap<Tier, DeleteTierRequest>().ReverseMap();
            CreateMap<Tier, UpdateTierRequest>().ReverseMap();

            //entities
            CreateMap<TierEntity, GetTierEntityResponse>().ReverseMap();
            CreateMap<TierEntity, AddTierEntityRequest>().ReverseMap();
            CreateMap<TierEntity, GetTierEntityRequest>().ReverseMap();
            CreateMap<TierEntity, DeleteTierEntityRequest>().ReverseMap();
            CreateMap<TierEntity, UpdateTierEntityRequest>().ReverseMap();

            //parameters
            CreateMap<TierParameter, GetTierParameterResponse>().ReverseMap();
            CreateMap<TierParameter, AddTierParameterRequest>().ReverseMap();
            CreateMap<TierParameter, GetTierParameterRequest>().ReverseMap();
            CreateMap<TierParameter, DeleteTierParameterRequest>().ReverseMap();
            CreateMap<TierParameter, UpdateTierParameterRequest>().ReverseMap();
        }
    }
}
