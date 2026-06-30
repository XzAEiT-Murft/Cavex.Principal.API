using AutoMapper;
using Cavex.Principal.API.Dtos.VehRefaccionesUsadas;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehRefaccionesUsadasProfile : Profile
    {
        public VehRefaccionesUsadasProfile()
        {
            CreateMap<VehRefaccionesUsadas, VehRefaccionesUsadasDto>();
            CreateMap<VehRefaccionesUsadasCreateDto, VehRefaccionesUsadas>();
            CreateMap<VehRefaccionesUsadasUpdateDto, VehRefaccionesUsadas>();
        }
    }
}
