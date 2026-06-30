using AutoMapper;
using Cavex.Principal.API.Dtos.VehInfracciones;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehInfraccionesProfile : Profile
    {
        public VehInfraccionesProfile()
        {
            CreateMap<VehInfracciones, VehInfraccionesDto>();
            CreateMap<VehInfraccionesCreateDto, VehInfracciones>();
            CreateMap<VehInfraccionesUpdateDto, VehInfracciones>();
        }
    }
}
