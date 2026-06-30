using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatMarcaLlanta;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatMarcaLlantaProfile : Profile
    {
        public VehCatMarcaLlantaProfile()
        {
            CreateMap<VehCatMarcaLlanta, VehCatMarcaLlantaDto>();
            CreateMap<VehCatMarcaLlantaCreateDto, VehCatMarcaLlanta>();
            CreateMap<VehCatMarcaLlantaUpdateDto, VehCatMarcaLlanta>();
        }
    }
}
