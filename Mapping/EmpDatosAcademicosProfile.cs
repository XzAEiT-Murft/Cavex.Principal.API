using AutoMapper;
using Cavex.Principal.API.Dtos.EmpDatosAcademicos;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpDatosAcademicosProfile : Profile
    {
        public EmpDatosAcademicosProfile()
        {
            CreateMap<EmpDatosAcademicos, EmpDatosAcademicosDto>();
            CreateMap<EmpDatosAcademicosCreateDto, EmpDatosAcademicos>();
            CreateMap<EmpDatosAcademicosUpdateDto, EmpDatosAcademicos>();
        }
    }
}