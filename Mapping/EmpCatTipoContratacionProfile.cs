using AutoMapper;
using Cavex.Principal.API.Dtos.EmpCatTipoContratacion;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpCatTipoContratacionProfile : Profile
    {
        public EmpCatTipoContratacionProfile()
        {
            CreateMap<EmpCatTipoContratacion, EmpCatTipoContratacionDto>();
            CreateMap<EmpCatTipoContratacionCreateDto, EmpCatTipoContratacion>();
            CreateMap<EmpCatTipoContratacionUpdateDto, EmpCatTipoContratacion>();
        }
    }
}