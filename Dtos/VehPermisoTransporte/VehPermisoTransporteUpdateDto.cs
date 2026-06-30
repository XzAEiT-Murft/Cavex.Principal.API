using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehPermisoTransporte
{
    public class VehPermisoTransporteUpdateDto
    {
        public int IdVehDatosGenerales { get; set; }

        [Required]
        [MaxLength(50)]
        public string StrNumeroPermiso { get; set; } = string.Empty;

        public int IdVehCatTipoPermiso { get; set; }

        [Required]
        [MaxLength(50)]
        public string StrAutoridad { get; set; } = string.Empty;

        public DateOnly DteFechaExpedicion { get; set; }

        public DateOnly DteFechaVencimiento { get; set; }

        public decimal MnyMontoPagado { get; set; }

        public int IdVehFormaPago { get; set; }

        [MaxLength(2048)]
        public string? StrUrlComprobantePago { get; set; }

        [MaxLength(2048)]
        public string? StrUrlPermisoTransporte { get; set; }

        public int IdVehCatStatus { get; set; }
    }
}
