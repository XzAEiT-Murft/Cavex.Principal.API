using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatHolograma;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatHologramaProfile : Profile
    {
        public VehCatHologramaProfile()
        {
            CreateMap<VehCatHolograma, VehCatHologramaDto>();
            CreateMap<VehCatHologramaCreateDto, VehCatHolograma>();
            CreateMap<VehCatHologramaUpdateDto, VehCatHolograma>();
        }
    }
}
