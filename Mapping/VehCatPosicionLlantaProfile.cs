using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatPosicionLlanta;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatPosicionLlantaProfile : Profile
    {
        public VehCatPosicionLlantaProfile()
        {
            CreateMap<VehCatPosicionLlanta, VehCatPosicionLlantaDto>();
            CreateMap<VehCatPosicionLlantaCreateDto, VehCatPosicionLlanta>();
            CreateMap<VehCatPosicionLlantaUpdateDto, VehCatPosicionLlanta>();
        }
    }
}
