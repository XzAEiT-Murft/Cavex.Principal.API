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
            CreateMap<EmpEmpleadoCreateDto, EmpEmpleado>()
                .ForMember(dest => dest.IntNss, opt => opt.MapFrom(src => src.BigNss));
            CreateMap<EmpEmpleadoUpdateDto, EmpEmpleado>()
                .ForMember(dest => dest.IntNss, opt => opt.MapFrom(src => src.BigNss));
        }
    }
}
