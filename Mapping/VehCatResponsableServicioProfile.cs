using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatResponsableServicio;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatResponsableServicioProfile : Profile
    {
        public VehCatResponsableServicioProfile()
        {
            CreateMap<VehCatResponsableServicio, VehCatResponsableServicioDto>();
            CreateMap<VehCatResponsableServicioCreateDto, VehCatResponsableServicio>();
            CreateMap<VehCatResponsableServicioUpdateDto, VehCatResponsableServicio>();
        }
    }
}
