using AutoMapper;
using Cavex.Principal.API.Dtos.CatSucursales;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class CatSucursalesProfile : Profile
    {
        public CatSucursalesProfile()
        {
            CreateMap<CatSucursales, CatSucursalesDto>();
            CreateMap<CatSucursalesCreateDto, CatSucursales>();
            CreateMap<CatSucursalesUpdateDto, CatSucursales>();
        }
    }
}
