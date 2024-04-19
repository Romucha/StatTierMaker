using AutoMapper;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.DTO.Requests.Entities;
using StatTierMaker.Db.DTO.Requests.Lists;
using StatTierMaker.Db.DTO.Requests.Parameters;
using StatTierMaker.Db.DTO.Requests.Tiers;
using StatTierMaker.Db.DTO.Responces.Entities;
using StatTierMaker.Db.DTO.Responces.Lists;
using StatTierMaker.Db.DTO.Responces.Parameters;
using StatTierMaker.Db.DTO.Responces.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Mapping
{
    internal class TierMapperProfile : Profile
    {
        public TierMapperProfile() 
        {
            //tiers
            CreateMap<Tier, GetTierResponce>().ReverseMap();
            CreateMap<Tier, AddTierRequest>().ReverseMap();
            CreateMap<Tier, GetTietRequest>().ReverseMap();
            CreateMap<Tier, DeleteTierRequest>().ReverseMap();
            CreateMap<Tier, UpdateTierRequest>().ReverseMap();

            //lists
            CreateMap<TierList, GetListResponce>().ReverseMap();
            CreateMap<TierList, AddListRequest>().ReverseMap();
            CreateMap<TierList, GetListRequest>().ReverseMap();
            CreateMap<TierList, DeleteListRequest>().ReverseMap();
            CreateMap<TierList, UpdateListRequest>().ReverseMap();

            //entities
            CreateMap<TierEntity, GetEntityResponce>().ReverseMap();
            CreateMap<TierEntity, AddEntityRequest>().ReverseMap();
            CreateMap<TierEntity, GetEntityRequest>().ReverseMap();
            CreateMap<TierEntity, DeleteEntityRequest>().ReverseMap();
            CreateMap<TierEntity, UpdateEntityRequest>().ReverseMap();

            //parameters
            CreateMap<TierParameter, GetParameterResponce>().ReverseMap();
            CreateMap<TierParameter, AddParameterRequest>().ReverseMap();
            CreateMap<TierParameter, GetParameterRequest>().ReverseMap();
            CreateMap<TierParameter, DeleteParameterRequest>().ReverseMap();
            CreateMap<TierParameter, UpdateParameterRequest>().ReverseMap();
        }
    }
}
