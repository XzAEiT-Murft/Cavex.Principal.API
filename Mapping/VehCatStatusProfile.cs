using AutoMapper;
using Cavex.Principal.API.Dtos.VehCatStatus;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehCatStatusProfile : Profile
    {
        public VehCatStatusProfile()
        {
            CreateMap<VehCatStatus, VehCatStatusDto>();
            CreateMap<VehCatStatusCreateDto, VehCatStatus>();
            CreateMap<VehCatStatusUpdateDto, VehCatStatus>();
        }
    }
}
