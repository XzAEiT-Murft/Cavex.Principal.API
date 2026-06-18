using AutoMapper;
using Cavex.Principal.API.Dtos.EmpExperiencia;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpExperienciaProfile : Profile
    {
        public EmpExperienciaProfile()
        {
            CreateMap<EmpExperiencia, EmpExperienciaDto>();
            CreateMap<EmpExperienciaCreateDto, EmpExperiencia>();
            CreateMap<EmpExperienciaUpdateDto, EmpExperiencia>();
        }
    }
}
