using AutoMapper;
using Cavex.Principal.API.Dtos.VehDatosGenerales;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehDatosGeneralesProfile : Profile
    {
        public VehDatosGeneralesProfile()
        {
            CreateMap<VehDatosGenerales, VehDatosGeneralesDto>();
            CreateMap<VehDatosGeneralesCreateDto, VehDatosGenerales>();
            CreateMap<VehDatosGeneralesUpdateDto, VehDatosGenerales>();
        }
    }
}
