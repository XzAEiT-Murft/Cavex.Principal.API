using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatGasolineras;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatGasolinerasProfile : Profile
    {
        public VehCatGasolinerasProfile()
        {
            CreateMap<VehCatGasolineras, VehCatGasolinerasDto>();
            CreateMap<VehCatGasolinerasCreateDto, VehCatGasolineras>();
            CreateMap<VehCatGasolinerasUpdateDto, VehCatGasolineras>();
        }
    }
}
