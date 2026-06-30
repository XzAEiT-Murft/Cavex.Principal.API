using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatTaller;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatTallerProfile : Profile
    {
        public VehCatTallerProfile()
        {
            CreateMap<VehCatTaller, VehCatTallerDto>();
            CreateMap<VehCatTallerCreateDto, VehCatTaller>();
            CreateMap<VehCatTallerUpdateDto, VehCatTaller>();
        }
    }
}
