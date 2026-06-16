using AutoMapper;
using Cavex.Principal.API.Dtos.EmpCatEntidadFederativa;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpCatEntidadFederativaProfile : Profile
    {
        public EmpCatEntidadFederativaProfile()
        {
            CreateMap<EmpCatEntidadFederativa, EmpCatEntidadFederativaDto>();
            CreateMap<EmpCatEntidadFederativaCreateDto, EmpCatEntidadFederativa>();
            CreateMap<EmpCatEntidadFederativaUpdateDto, EmpCatEntidadFederativa>();
        }
    }
}