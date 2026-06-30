using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatFormaPago;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatFormaPagoProfile : Profile
    {
        public VehCatFormaPagoProfile()
        {
            CreateMap<VehCatFormaPago, VehCatFormaPagoDto>();
            CreateMap<VehCatFormaPagoCreateDto, VehCatFormaPago>();
            CreateMap<VehCatFormaPagoUpdateDto, VehCatFormaPago>();
        }
    }
}
