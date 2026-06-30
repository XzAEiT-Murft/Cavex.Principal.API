using AutoMapper;
using Cavex.Principal.API.Dtos.VehPermisoTransporte;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehPermisoTransporteProfile : Profile
    {
        public VehPermisoTransporteProfile()
        {
            CreateMap<VehPermisoTransporte, VehPermisoTransporteDto>();
            CreateMap<VehPermisoTransporteCreateDto, VehPermisoTransporte>();
            CreateMap<VehPermisoTransporteUpdateDto, VehPermisoTransporte>();
        }
    }
}
