using AutoMapper;
using Cavex.Principal.API.Dtos.EmpCatPais;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpCatPaisProfile : Profile
    {
        public EmpCatPaisProfile()
        {
            CreateMap<EmpCatPais, EmpCatPaisDto>();
            CreateMap<EmpCatPaisCreateDto, EmpCatPais>();
            CreateMap<EmpCatPaisUpdateDto, EmpCatPais>();
        }
    }
}