using AutoMapper;
using Cavex.Principal.API.Dtos.VehAsignacionVehiculos;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehAsignacionVehiculosProfile : Profile
    {
        public VehAsignacionVehiculosProfile()
        {
            CreateMap<VehAsignacionVehiculos, VehAsignacionVehiculosDto>();
            CreateMap<VehAsignacionVehiculosCreateDto, VehAsignacionVehiculos>();
            CreateMap<VehAsignacionVehiculosUpdateDto, VehAsignacionVehiculos>();
        }
    }
}
