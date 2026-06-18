using AutoMapper;
using Cavex.Principal.API.Dtos.EmpCondicionesLaborales;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpCondicionesLaboralesProfile : Profile
    {
        public EmpCondicionesLaboralesProfile()
        {
            CreateMap<EmpCondicionesLaborales, EmpCondicionesLaboralesDto>();
            CreateMap<EmpCondicionesLaboralesCreateDto, EmpCondicionesLaborales>();
            CreateMap<EmpCondicionesLaboralesUpdateDto, EmpCondicionesLaborales>();
        }
    }
}