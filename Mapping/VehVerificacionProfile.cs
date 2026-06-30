using AutoMapper;
using Cavex.Principal.API.Dtos.VehVerificacion;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehVerificacionProfile : Profile
    {
        public VehVerificacionProfile()
        {
            CreateMap<VehVerificacion, VehVerificacionDto>();
            CreateMap<VehVerificacionCreateDto, VehVerificacion>();
            CreateMap<VehVerificacionUpdateDto, VehVerificacion>();
        }
    }
}
