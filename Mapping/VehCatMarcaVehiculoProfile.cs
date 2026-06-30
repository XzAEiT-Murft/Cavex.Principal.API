using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatMarcaVehiculo;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatMarcaVehiculoProfile : Profile
    {
        public VehCatMarcaVehiculoProfile()
        {
            CreateMap<VehCatMarcaVehiculo, VehCatMarcaVehiculoDto>();
            CreateMap<VehCatMarcaVehiculoCreateDto, VehCatMarcaVehiculo>();
            CreateMap<VehCatMarcaVehiculoUpdateDto, VehCatMarcaVehiculo>();
        }
    }
}
