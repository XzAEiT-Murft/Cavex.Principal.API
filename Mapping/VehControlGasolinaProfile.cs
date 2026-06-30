using AutoMapper;
using Cavex.Principal.API.Dtos.VehControlGasolina;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehControlGasolinaProfile : Profile
    {
        public VehControlGasolinaProfile()
        {
            CreateMap<VehControlGasolina, VehControlGasolinaDto>();
            CreateMap<VehControlGasolinaCreateDto, VehControlGasolina>();
            CreateMap<VehControlGasolinaUpdateDto, VehControlGasolina>();
        }
    }
}
