using AutoMapper;
using Cavex.Principal.API.Dtos.EmpDireccion;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpDireccionProfile : Profile
    {
        public EmpDireccionProfile()
        {
            CreateMap<EmpDireccion, EmpDireccionDto>();
            CreateMap<EmpDireccionCreateDto, EmpDireccion>();
            CreateMap<EmpDireccionUpdateDto, EmpDireccion>();
        }
    }
}