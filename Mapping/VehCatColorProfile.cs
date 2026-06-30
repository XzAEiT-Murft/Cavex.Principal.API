using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatColor;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatColorProfile : Profile
    {
        public VehCatColorProfile()
        {
            CreateMap<VehCatColor, VehCatColorDto>();
            CreateMap<VehCatColorCreateDto, VehCatColor>();
            CreateMap<VehCatColorUpdateDto, VehCatColor>();
        }
    }
}
