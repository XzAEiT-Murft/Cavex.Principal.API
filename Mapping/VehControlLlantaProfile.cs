using AutoMapper;
using Cavex.Principal.API.Dtos.VehControlLlanta;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehControlLlantaProfile : Profile
    {
        public VehControlLlantaProfile()
        {
            CreateMap<VehControlLlanta, VehControlLlantaDto>();
            CreateMap<VehControlLlantaCreateDto, VehControlLlanta>();
            CreateMap<VehControlLlantaUpdateDto, VehControlLlanta>();
        }
    }
}
