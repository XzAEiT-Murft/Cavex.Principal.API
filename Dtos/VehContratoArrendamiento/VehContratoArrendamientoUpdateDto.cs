using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehContratoArrendamiento
{
    public class VehContratoArrendamientoUpdateDto
    {
        public int IdVehDatosGenerales { get; set; }

        public int IdVehCatArrendatario { get; set; }

        [Required]
        [MaxLength(50)]
        public string StrNumeroContrato { get; set; } = string.Empty;

        public DateOnly DteFechaInicio { get; set; }

        public DateOnly DteFechaFin { get; set; }

        public decimal MnyMontoPagado { get; set; }

        public int IdVehFormaPago { get; set; }

        [MaxLength(2048)]
        public string? StrUrlComprobantePago { get; set; }

        [MaxLength(50)]
        public string? StrPeriodoPago { get; set; }

        public int IdVehCatStatus { get; set; }

        [MaxLength(2048)]
        public string? StrUrlContratoArrendamiento { get; set; }
    }
}
