using AutoMapper;
using Cavex.Principal.API.Dtos.VehDaniosAccidentes;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehDaniosAccidentesProfile : Profile
    {
        public VehDaniosAccidentesProfile()
        {
            CreateMap<VehDaniosAccidentes, VehDaniosAccidentesDto>();
            CreateMap<VehDaniosAccidentesCreateDto, VehDaniosAccidentes>();
            CreateMap<VehDaniosAccidentesUpdateDto, VehDaniosAccidentes>();
        }
    }
}
