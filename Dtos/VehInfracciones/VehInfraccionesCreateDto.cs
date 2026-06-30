using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehInfracciones
{
    public class VehInfraccionesCreateDto
    {
        public int IdVehDatosGenerales { get; set; }

        public int IdEmpEmpleado { get; set; }

        public DateOnly DteFechaInfraccion { get; set; }

        [Required]
        [MaxLength(500)]
        public string StrMotivo { get; set; } = string.Empty;

        public decimal? MnyMontoPagado { get; set; }

        public int IdVehCatStatus { get; set; }

        public DateOnly? DteFechaPago { get; set; }

        public int? IdVehFormaPago { get; set; }

        [MaxLength(2048)]
        public string? StrUrlComprobantePago { get; set; }

        [MaxLength(500)]
        public string? StrObservaciones { get; set; }
    }
}
