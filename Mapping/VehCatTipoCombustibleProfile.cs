using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatTipoCombustible;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatTipoCombustibleProfile : Profile
    {
        public VehCatTipoCombustibleProfile()
        {
            CreateMap<VehCatTipoCombustible, VehCatTipoCombustibleDto>();
            CreateMap<VehCatTipoCombustibleCreateDto, VehCatTipoCombustible>();
            CreateMap<VehCatTipoCombustibleUpdateDto, VehCatTipoCombustible>();
        }
    }
}
