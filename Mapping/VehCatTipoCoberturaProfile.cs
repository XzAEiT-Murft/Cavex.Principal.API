using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatTipoCobertura;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatTipoCoberturaProfile : Profile
    {
        public VehCatTipoCoberturaProfile()
        {
            CreateMap<VehCatTipoCobertura, VehCatTipoCoberturaDto>();
            CreateMap<VehCatTipoCoberturaCreateDto, VehCatTipoCobertura>();
            CreateMap<VehCatTipoCoberturaUpdateDto, VehCatTipoCobertura>();
        }
    }
}
