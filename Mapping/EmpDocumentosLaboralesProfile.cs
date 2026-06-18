using AutoMapper;
using Cavex.Principal.API.Dtos.EmpDocumentosLaborales;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class EmpDocumentosLaboralesProfile : Profile
    {
        public EmpDocumentosLaboralesProfile()
        {
            CreateMap<EmpDocumentosLaborales, EmpDocumentosLaboralesDto>();
            CreateMap<EmpDocumentosLaboralesCreateDto, EmpDocumentosLaborales>();
            CreateMap<EmpDocumentosLaboralesUpdateDto, EmpDocumentosLaborales>();
        }
    }
}
