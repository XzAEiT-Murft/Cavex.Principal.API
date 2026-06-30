using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatTipoVehiculo;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatTipoVehiculoProfile : Profile
    {
        public VehCatTipoVehiculoProfile()
        {
            CreateMap<VehCatTipoVehiculo, VehCatTipoVehiculoDto>();
            CreateMap<VehCatTipoVehiculoCreateDto, VehCatTipoVehiculo>();
            CreateMap<VehCatTipoVehiculoUpdateDto, VehCatTipoVehiculo>();
        }
    }
}
