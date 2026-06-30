using AutoMapper;
using Cavex.Principal.API.Dtos.VehRevistaVehicular;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehRevistaVehicularProfile : Profile
    {
        public VehRevistaVehicularProfile()
        {
            CreateMap<VehRevistaVehicular, VehRevistaVehicularDto>();
            CreateMap<VehRevistaVehicularCreateDto, VehRevistaVehicular>();
            CreateMap<VehRevistaVehicularUpdateDto, VehRevistaVehicular>();
        }
    }
}
