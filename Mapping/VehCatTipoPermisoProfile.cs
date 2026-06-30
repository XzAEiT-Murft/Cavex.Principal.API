using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatTipoPermiso;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatTipoPermisoProfile : Profile
    {
        public VehCatTipoPermisoProfile()
        {
            CreateMap<VehCatTipoPermiso, VehCatTipoPermisoDto>();
            CreateMap<VehCatTipoPermisoCreateDto, VehCatTipoPermiso>();
            CreateMap<VehCatTipoPermisoUpdateDto, VehCatTipoPermiso>();
        }
    }
}
