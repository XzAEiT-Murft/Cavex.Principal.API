using AutoMapper;
using Cavex.Principal.API.Dtos.EmpCatColonia;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpCatColoniaProfile : Profile
    {
        public EmpCatColoniaProfile()
        {
            CreateMap<EmpCatColonia, EmpCatColoniaDto>();
            CreateMap<EmpCatColoniaCreateDto, EmpCatColonia>();
            CreateMap<EmpCatColoniaUpdateDto, EmpCatColonia>();
        }
    }
}
