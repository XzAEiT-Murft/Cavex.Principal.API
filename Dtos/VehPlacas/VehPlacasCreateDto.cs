using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehPlacas
{
    public class VehPlacasCreateDto
    {
        public int IdVehDatosGenerales { get; set; }

        [Required]
        [MaxLength(50)]
        public string StrNumPlaca { get; set; } = string.Empty;

        public int IdEmpCatEntidadFederativa { get; set; }

        public DateOnly DteFechaAsignacion { get; set; }

        public DateOnly DteFechaVencimiento { get; set; }

        public decimal MnyMontoPagado { get; set; }

        public int IdVehCatFormaPago { get; set; }

        [MaxLength(2048)]
        public string? StrUrlComprobantePago { get; set; }

        public int IdVehCatStatus { get; set; }

        [MaxLength(2048)]
        public string? StrUrlPlacas { get; set; }
    }
}
