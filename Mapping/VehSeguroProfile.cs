using AutoMapper;
using Cavex.Principal.API.Dtos.VehSeguro;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehSeguroProfile : Profile
    {
        public VehSeguroProfile()
        {
            CreateMap<VehSeguro, VehSeguroDto>();
            CreateMap<VehSeguroCreateDto, VehSeguro>();
            CreateMap<VehSeguroUpdateDto, VehSeguro>();
        }
    }
}
