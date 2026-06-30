using AutoMapper;
using Cavex.Principal.API.Dtos.VehTarjetaCirculacion;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehTarjetaCirculacionProfile : Profile
    {
        public VehTarjetaCirculacionProfile()
        {
            CreateMap<VehTarjetaCirculacion, VehTarjetaCirculacionDto>();
            CreateMap<VehTarjetaCirculacionCreateDto, VehTarjetaCirculacion>();
            CreateMap<VehTarjetaCirculacionUpdateDto, VehTarjetaCirculacion>();
        }
    }
}
