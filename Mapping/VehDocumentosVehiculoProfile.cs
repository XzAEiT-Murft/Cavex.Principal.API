using AutoMapper;
using Cavex.Principal.API.Dtos.VehDocumentosVehiculo;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehDocumentosVehiculoProfile : Profile
    {
        public VehDocumentosVehiculoProfile()
        {
            CreateMap<VehDocumentosVehiculo, VehDocumentosVehiculoDto>();
            CreateMap<VehDocumentosVehiculoCreateDto, VehDocumentosVehiculo>();
            CreateMap<VehDocumentosVehiculoUpdateDto, VehDocumentosVehiculo>();
        }
    }
}
