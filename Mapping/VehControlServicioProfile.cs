using AutoMapper;
using Cavex.Principal.API.Dtos.VehControlServicio;
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Mapping
{
    public class VehControlServicioProfile : Profile
    {
        public VehControlServicioProfile()
        {
            CreateMap<VehControlServicio, VehControlServicioDto>()
                .ForMember(dest => dest.IdVehCatTipoServicio, opt => opt.MapFrom(src => src.VehServicioDetalle != null ? src.VehServicioDetalle.IdVehCatTipoServicio : 0))
                .ForMember(dest => dest.DteFechaServicio, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.DteFechaInicio)))
                .ForMember(dest => dest.DteFechaFin, opt => opt.MapFrom(src => src.VehServicioDetalle != null ? src.VehServicioDetalle.DteFechaFin : (DateTime?)null))
                .ForMember(dest => dest.DecKilometrajeActual, opt => opt.MapFrom(src => Convert.ToDecimal(src.BigKilometrajeActual)))
                .ForMember(dest => dest.MnyCostoManoObra, opt => opt.MapFrom(src => src.VehServicioDetalle != null ? src.VehServicioDetalle.MnyCostoManoObra : null))
                .ForMember(dest => dest.MnyCostoRefacciones, opt => opt.MapFrom(src => src.VehServicioDetalle != null ? src.VehServicioDetalle.MnyCostoRefacciones : null))
                .ForMember(dest => dest.MnyCostoTotal, opt => opt.MapFrom(src => src.VehServicioDetalle != null ? src.VehServicioDetalle.MnyCostoTotal : null))
                .ForMember(dest => dest.IntProximoServicioPorKm, opt => opt.MapFrom(src => src.VehServicioDetalle != null && src.VehServicioDetalle.BigProximoServicioKm.HasValue ? Convert.ToInt32(src.VehServicioDetalle.BigProximoServicioKm.Value) : (int?)null))
                .ForMember(dest => dest.DteProximoServicioPorFecha, opt => opt.MapFrom(src => src.VehServicioDetalle != null ? src.VehServicioDetalle.DateProximoServicioFecha : null))
                .ForMember(dest => dest.IdVehFormaPago, opt => opt.MapFrom(src => src.VehServicioDetalle != null ? src.VehServicioDetalle.IdVehCatFormaPago : 0))
                .ForMember(dest => dest.StrUrlComprobantePago, opt => opt.MapFrom(src => src.VehServicioDetalle != null ? src.VehServicioDetalle.StrUrlComprobantePago : null));

            CreateMap<VehControlServicioCreateDto, VehControlServicio>()
                .ForMember(dest => dest.DteFechaInicio, opt => opt.MapFrom(src => src.DteFechaServicio.ToDateTime(TimeOnly.MinValue)))
                .ForMember(dest => dest.BigKilometrajeActual, opt => opt.MapFrom(src => Convert.ToInt64(src.DecKilometrajeActual)))
                .ForMember(dest => dest.VehServicioDetalle, opt => opt.MapFrom(src => BuildDetalle(src)));

            CreateMap<VehControlServicioUpdateDto, VehControlServicio>()
                .ForMember(dest => dest.DteFechaInicio, opt => opt.MapFrom(src => src.DteFechaServicio.ToDateTime(TimeOnly.MinValue)))
                .ForMember(dest => dest.BigKilometrajeActual, opt => opt.MapFrom(src => Convert.ToInt64(src.DecKilometrajeActual)))
                .ForMember(dest => dest.VehServicioDetalle, opt => opt.MapFrom(src => BuildDetalle(src)));
        }

        private static VehServicioDetalle? BuildDetalle(VehControlServicioCreateDto src)
        {
            if (src.IdVehCatTipoServicio <= 0 || src.IdVehFormaPago <= 0)
            {
                return null;
            }

            return new VehServicioDetalle
            {
                IdVehCatTipoServicio = src.IdVehCatTipoServicio,
                MnyCostoManoObra = src.MnyCostoManoObra,
                MnyCostoRefacciones = src.MnyCostoRefacciones,
                DteFechaFin = src.DteFechaFin ?? src.DteFechaServicio.ToDateTime(TimeOnly.MinValue),
                BigProximoServicioKm = src.IntProximoServicioPorKm,
                DateProximoServicioFecha = src.DteProximoServicioPorFecha,
                IdVehCatFormaPago = src.IdVehFormaPago,
                StrUrlComprobantePago = src.StrUrlComprobantePago,
                StrDescripcion = src.StrDescripcion
            };
        }

        private static VehServicioDetalle? BuildDetalle(VehControlServicioUpdateDto src)
        {
            if (src.IdVehCatTipoServicio <= 0 || src.IdVehFormaPago <= 0)
            {
                return null;
            }

            return new VehServicioDetalle
            {
                IdVehCatTipoServicio = src.IdVehCatTipoServicio,
                MnyCostoManoObra = src.MnyCostoManoObra,
                MnyCostoRefacciones = src.MnyCostoRefacciones,
                DteFechaFin = src.DteFechaFin ?? src.DteFechaServicio.ToDateTime(TimeOnly.MinValue),
                BigProximoServicioKm = src.IntProximoServicioPorKm,
                DateProximoServicioFecha = src.DteProximoServicioPorFecha,
                IdVehCatFormaPago = src.IdVehFormaPago,
                StrUrlComprobantePago = src.StrUrlComprobantePago,
                StrDescripcion = src.StrDescripcion
            };
        }
    }
}
