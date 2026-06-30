using AutoMapper;
using Cavex.Principal.API.Dtos.VehContratoArrendamiento;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehContratoArrendamientoProfile : Profile
    {
        public VehContratoArrendamientoProfile()
        {
            CreateMap<VehContratoArrendamiento, VehContratoArrendamientoDto>();
            CreateMap<VehContratoArrendamientoCreateDto, VehContratoArrendamiento>();
            CreateMap<VehContratoArrendamientoUpdateDto, VehContratoArrendamiento>();
        }
    }
}
