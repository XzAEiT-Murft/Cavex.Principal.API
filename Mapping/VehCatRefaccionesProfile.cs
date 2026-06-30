using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatRefacciones;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatRefaccionesProfile : Profile
    {
        public VehCatRefaccionesProfile()
        {
            CreateMap<VehCatRefacciones, VehCatRefaccionesDto>();
            CreateMap<VehCatRefaccionesCreateDto, VehCatRefacciones>();
            CreateMap<VehCatRefaccionesUpdateDto, VehCatRefacciones>();
        }
    }
}
