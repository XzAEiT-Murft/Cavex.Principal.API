using AutoMapper;
using Cavex.Principal.API.Dtos.EmpTelefono;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpTelefonoProfile : Profile
    {
        public EmpTelefonoProfile()
        {
            CreateMap<EmpTelefono, EmpTelefonoDto>()
                .ForMember(dest => dest.BigNumeroFijo, opt => opt.MapFrom(src => ParseLong(src.StrNumeroFijo)))
                .ForMember(dest => dest.BigNumeroCelular, opt => opt.MapFrom(src => ParseNullableLong(src.StrNumeroCelular)));
            CreateMap<EmpTelefonoCreateDto, EmpTelefono>()
                .ForMember(dest => dest.StrNumeroFijo, opt => opt.MapFrom(src => src.BigNumeroFijo.ToString()))
                .ForMember(dest => dest.StrNumeroCelular, opt => opt.MapFrom(src => src.BigNumeroCelular.HasValue ? src.BigNumeroCelular.Value.ToString() : null));
            CreateMap<EmpTelefonoUpdateDto, EmpTelefono>()
                .ForMember(dest => dest.StrNumeroFijo, opt => opt.MapFrom(src => src.BigNumeroFijo.ToString()))
                .ForMember(dest => dest.StrNumeroCelular, opt => opt.MapFrom(src => src.BigNumeroCelular.HasValue ? src.BigNumeroCelular.Value.ToString() : null));
        }

        private static long ParseLong(string val) => long.TryParse(val, out var res) ? res : 0;
        private static long? ParseNullableLong(string? val) => long.TryParse(val, out var res) ? (long?)res : null;
    }
}
