using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatAseguradora;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatAseguradoraProfile : Profile
    {
        public VehCatAseguradoraProfile()
        {
            CreateMap<VehCatAseguradora, VehCatAseguradoraDto>();
            CreateMap<VehCatAseguradoraCreateDto, VehCatAseguradora>();
            CreateMap<VehCatAseguradoraUpdateDto, VehCatAseguradora>();
        }
    }
}
