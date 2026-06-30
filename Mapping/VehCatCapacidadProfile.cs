using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatCapacidad;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatCapacidadProfile : Profile
    {
        public VehCatCapacidadProfile()
        {
            CreateMap<VehCatCapacidad, VehCatCapacidadDto>();
            CreateMap<VehCatCapacidadCreateDto, VehCatCapacidad>();
            CreateMap<VehCatCapacidadUpdateDto, VehCatCapacidad>();
        }
    }
}
