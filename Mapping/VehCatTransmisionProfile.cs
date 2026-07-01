using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatTransmision;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    /// <summary>
    /// Mapeos entre la entidad VehCatTransmision y sus contratos HTTP.
    /// </summary>
    public class VehCatTransmisionProfile : Profile
    {
        public VehCatTransmisionProfile()
        {
            CreateMap<VehCatTransmision, VehCatTransmisionDto>();
            CreateMap<VehCatTransmisionCreateDto, VehCatTransmision>();
            CreateMap<VehCatTransmisionUpdateDto, VehCatTransmision>();
        }
    }
}
