using AutoMapper;
using Cavex.Principal.API.Dtos.EmpCatAreaLaboral;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpCatAreaLaboralProfile:Profile
    {
        public EmpCatAreaLaboralProfile()
        {
            CreateMap<EmpCatAreaLaboral, EmpCatAreaLaboralDto>();
            CreateMap<EmpCatAreaLaboralCreateDto, EmpCatAreaLaboral>();
            CreateMap<EmpCatAreaLaboralUpdateDto, EmpCatAreaLaboral>();
        }
    }
}
