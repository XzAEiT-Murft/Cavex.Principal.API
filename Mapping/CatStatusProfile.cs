using AutoMapper;
using Cavex.Principal.API.Dtos.CatStatus;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class CatStatusProfile : Profile
    {
        public CatStatusProfile()
        {
            CreateMap<CatStatus, CatStatusDto>();
            CreateMap<CatStatusCreateDto, CatStatus>();
            CreateMap<CatStatusUpdateDto, CatStatus>();
        }
    }
}
