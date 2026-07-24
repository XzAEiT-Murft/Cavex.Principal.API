using AutoMapper;
using Cavex.Principal.API.Dtos.VehDatosGenerales;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehDatosGeneralesProfile : Profile
    {
        public VehDatosGeneralesProfile()
        {
            CreateMap<VehDatosGenerales, VehDatosGeneralesDto>()
                .ForMember(dest => dest.StrNumMotor, opt => opt.MapFrom(src => src.IntNumMotor.HasValue ? src.IntNumMotor.Value.ToString() : null));
            
            CreateMap<VehDatosGeneralesCreateDto, VehDatosGenerales>()
                .ForMember(dest => dest.IntNumMotor, opt => opt.MapFrom(src => ParseNumMotor(src.StrNumMotor)));
                
            CreateMap<VehDatosGeneralesUpdateDto, VehDatosGenerales>()
                .ForMember(dest => dest.IntNumMotor, opt => opt.MapFrom(src => ParseNumMotor(src.StrNumMotor)));
        }

        private static int? ParseNumMotor(string? str)
        {
            if (string.IsNullOrWhiteSpace(str)) return null;
            // Clean up any common non-numeric prefix or formatting just in case, but standard try parse is fine
            if (int.TryParse(str.Trim(), out int val)) return val;
            return null;
        }
    }
}
