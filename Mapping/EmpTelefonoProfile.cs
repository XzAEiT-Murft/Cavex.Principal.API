using AutoMapper;
using Cavex.Principal.API.Dtos.EmpTelefono;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpTelefonoProfile : Profile
    {
        public EmpTelefonoProfile()
        {
            CreateMap<EmpTelefono, EmpTelefonoDto>();
            CreateMap<EmpTelefonoCreateDto, EmpTelefono>()
                .ForMember(dest => dest.StrNumeroFijo, opt => opt.MapFrom(src => src.BigNumeroFijo.ToString()))
                .ForMember(dest => dest.StrNumeroCelular, opt => opt.MapFrom(src => src.BigNumeroCelular.HasValue ? src.BigNumeroCelular.Value.ToString() : null));
            CreateMap<EmpTelefonoUpdateDto, EmpTelefono>()
                .ForMember(dest => dest.StrNumeroFijo, opt => opt.MapFrom(src => src.BigNumeroFijo.ToString()))
                .ForMember(dest => dest.StrNumeroCelular, opt => opt.MapFrom(src => src.BigNumeroCelular.HasValue ? src.BigNumeroCelular.Value.ToString() : null));
        }
    }
}
