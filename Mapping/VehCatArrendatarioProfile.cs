using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatArrendatario;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatArrendatarioProfile : Profile
    {
        public VehCatArrendatarioProfile()
        {
            CreateMap<VehCatArrendatario, VehCatArrendatarioDto>();
            CreateMap<VehCatArrendatarioCreateDto, VehCatArrendatario>();
            CreateMap<VehCatArrendatarioUpdateDto, VehCatArrendatario>();
        }
    }
}
