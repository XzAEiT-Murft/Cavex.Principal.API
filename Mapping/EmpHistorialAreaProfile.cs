using AutoMapper;
using Cavex.Principal.API.Dtos.EmpHistorialArea;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpHistorialAreaProfile : Profile
    {
        public EmpHistorialAreaProfile()
        {
            CreateMap<EmpHistorialArea, EmpHistorialAreaDto>();
            CreateMap<EmpHistorialAreaCreateDto, EmpHistorialArea>();
            CreateMap<EmpHistorialAreaUpdateDto, EmpHistorialArea>();
        }
    }
}
