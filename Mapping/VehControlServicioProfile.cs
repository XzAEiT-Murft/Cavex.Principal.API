using AutoMapper;
using Cavex.Principal.API.Dtos.VehControlServicio;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehControlServicioProfile : Profile
    {
        public VehControlServicioProfile()
        {
            CreateMap<VehControlServicio, VehControlServicioDto>();
            CreateMap<VehControlServicioCreateDto, VehControlServicio>();
            CreateMap<VehControlServicioUpdateDto, VehControlServicio>();
        }
    }
}
