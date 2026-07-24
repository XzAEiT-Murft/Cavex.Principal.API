using AutoMapper;
using Cavex.Principal.API.Dtos.EmpCatColonia;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpCatColoniaProfile : Profile
    {
        public EmpCatColoniaProfile()
        {
            CreateMap<EmpCatColonia, EmpCatColoniaDto>()
                .ForMember(dest => dest.StrMunicipio, opt => opt.MapFrom(src => src.EmpCatMunicipio != null ? src.EmpCatMunicipio.StrValor : null))
                .ForMember(dest => dest.StrEstado, opt => opt.MapFrom(src => (src.EmpCatMunicipio != null && src.EmpCatMunicipio.EmpCatEntidadFederativa != null) ? src.EmpCatMunicipio.EmpCatEntidadFederativa.StrValor : null));
            CreateMap<EmpCatColoniaCreateDto, EmpCatColonia>();
            CreateMap<EmpCatColoniaUpdateDto, EmpCatColonia>();
        }
    }
}
