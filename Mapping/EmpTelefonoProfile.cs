using AutoMapper;
using Cavex.Principal.API.Dtos.EmpTelefono;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpTelefonoProfile : Profile
    {
        public EmpTelefonoProfile()
        {
            CreateMap<EmpTelefono, EmpTelefonoDto>();
            CreateMap<EmpTelefonoCreateDto, EmpTelefono>();
            CreateMap<EmpTelefonoUpdateDto, EmpTelefono>();
        }
    }
}