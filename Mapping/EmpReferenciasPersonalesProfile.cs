using AutoMapper;
using Cavex.Principal.API.Dtos.EmpReferenciasPersonales;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpReferenciasPersonalesProfile : Profile
    {
        public EmpReferenciasPersonalesProfile()
        {
            CreateMap<EmpReferenciasPersonales, EmpReferenciasPersonalesDto>();
            CreateMap<EmpReferenciasPersonalesCreateDto, EmpReferenciasPersonales>()
                .ForMember(dest => dest.IntTelefono, opt => opt.MapFrom(src => src.BigTelefono));
            CreateMap<EmpReferenciasPersonalesUpdateDto, EmpReferenciasPersonales>()
                .ForMember(dest => dest.IntTelefono, opt => opt.MapFrom(src => src.BigTelefono));
        }
    }
}
