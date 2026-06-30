using AutoMapper;
using Cavex.Principal.API.Dtos.VehPlacas;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehPlacasProfile : Profile
    {
        public VehPlacasProfile()
        {
            CreateMap<VehPlacas, VehPlacasDto>();
            CreateMap<VehPlacasCreateDto, VehPlacas>();
            CreateMap<VehPlacasUpdateDto, VehPlacas>();
        }
    }
}
