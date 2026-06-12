using AutoMapper;
using Cavex.Principal.API.Dtos.CatServicios;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class CatServiciosProfile : Profile
    {
        public CatServiciosProfile()
        {
            CreateMap<CatServicios, CatServiciosDto>();
            CreateMap<CatServiciosCreateDto, CatServicios>();
            CreateMap<CatServiciosUpdateDto, CatServicios>();
        }
    }
}
