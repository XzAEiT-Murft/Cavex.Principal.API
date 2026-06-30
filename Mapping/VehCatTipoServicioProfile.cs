using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatTipoServicio;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatTipoServicioProfile : Profile
    {
        public VehCatTipoServicioProfile()
        {
            CreateMap<VehCatTipoServicio, VehCatTipoServicioDto>();
            CreateMap<VehCatTipoServicioCreateDto, VehCatTipoServicio>();
            CreateMap<VehCatTipoServicioUpdateDto, VehCatTipoServicio>();
        }
    }
}
