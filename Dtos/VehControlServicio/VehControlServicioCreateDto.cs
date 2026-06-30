using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehControlServicio
{
    public class VehControlServicioCreateDto
    {
        public int IdVehDatosGenerales { get; set; }

        public int IdVehCatTipoServicio { get; set; }

        public DateOnly DteFechaServicio { get; set; }

        public decimal DecKilometrajeActual { get; set; }

        public int IdVehCatTaller { get; set; }

        [MaxLength(500)]
        public string? StrDescripcion { get; set; }

        public decimal MnyCostoManoObra { get; set; }

        public decimal MnyCostoRefacciones { get; set; }

        public int? IntProximoServicioPorKm { get; set; }

        public DateOnly? DteProximoServicioPorFecha { get; set; }

        public int IdVehFormaPago { get; set; }

        [MaxLength(2048)]
        public string? StrUrlComprobantePago { get; set; }

        public int IdVehCatResponsableServicio { get; set; }
    }
}
