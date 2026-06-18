using AutoMapper;
using Cavex.Principal.API.Dtos.EmpEmpleado;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpEmpleadoProfile : Profile
    {
        public EmpEmpleadoProfile()
        {
            CreateMap<EmpEmpleado, EmpEmpleadoDto>();
            CreateMap<EmpEmpleadoCreateDto, EmpEmpleado>();
            CreateMap<EmpEmpleadoUpdateDto, EmpEmpleado>();
        }
    }
}
