using AutoMapper;
using Cavex.Principal.API.Dtos.VehTenencia;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehTenenciaProfile : Profile
    {
        public VehTenenciaProfile()
        {
            CreateMap<VehTenencia, VehTenenciaDto>();
            CreateMap<VehTenenciaCreateDto, VehTenencia>();
            CreateMap<VehTenenciaUpdateDto, VehTenencia>();
        }
    }
}
