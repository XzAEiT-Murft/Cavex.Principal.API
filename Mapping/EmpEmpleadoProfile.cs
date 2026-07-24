using AutoMapper;
using Cavex.Principal.API.Dtos.EmpEmpleado;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpEmpleadoProfile : Profile
    {
        public EmpEmpleadoProfile()
        {
            CreateMap<EmpEmpleado, EmpEmpleadoDto>()
                .ForMember(dest => dest.StrEmpCatGenero, opt => opt.MapFrom(src => GetGeneroStr(src)))
                .ForMember(dest => dest.StrEmpCatEstadoCivil, opt => opt.MapFrom(src => GetEstadoCivilStr(src)))
                .ForMember(dest => dest.StrEmpCatNacionalidad, opt => opt.MapFrom(src => GetNacionalidadStr(src)))
                .ForMember(dest => dest.StrEmpCatTipoContratacion, opt => opt.MapFrom(src => GetTipoContratacionStr(src)))
                .ForMember(dest => dest.StrEmpDireccion, opt => opt.MapFrom(src => string.Empty))
                .ForMember(dest => dest.StrEmpDatosAcademicos, opt => opt.MapFrom(src => string.Empty))
                .ForMember(dest => dest.StrEmpDocumentosLaborales, opt => opt.MapFrom(src => string.Empty))
                .ForMember(dest => dest.StrEmpCondicionesLaborales, opt => opt.MapFrom(src => GetAreaLaboralStr(src)))
                .ForMember(dest => dest.StrCatStatus, opt => opt.MapFrom(src => GetCatStatusStr(src)));
            CreateMap<EmpEmpleadoCreateDto, EmpEmpleado>();
            CreateMap<EmpEmpleadoUpdateDto, EmpEmpleado>();
        }

        private static string GetGeneroStr(EmpEmpleado src) => src.EmpCatGenero?.StrValor ?? string.Empty;
        private static string GetEstadoCivilStr(EmpEmpleado src) => src.EmpCatEstadoCivil?.StrValor ?? string.Empty;
        private static string GetNacionalidadStr(EmpEmpleado src) => src.EmpCatNacionalidad?.StrValor ?? string.Empty;
        private static string GetTipoContratacionStr(EmpEmpleado src) => src.EmpCatTipoContratacion?.StrValor ?? string.Empty;
        private static string GetCatStatusStr(EmpEmpleado src) => src.CatStatus?.StrValor ?? string.Empty;
        private static string GetAreaLaboralStr(EmpEmpleado src)
        {
            if (src.EmpHistorialAreas == null) return "Sin Condiciones Laborales";
            var latest = src.EmpHistorialAreas.Where(h => h.EmpCatAreaLaboral != null).OrderByDescending(h => h.DteFechaInicio).FirstOrDefault();
            return latest?.EmpCatAreaLaboral?.StrValor ?? "Sin Condiciones Laborales";
        }
    }
}
