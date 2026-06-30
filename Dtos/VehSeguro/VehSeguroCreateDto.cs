using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehSeguro
{
    public class VehSeguroCreateDto
    {
        public int IdVehDatosGenerales { get; set; }

        public int IdVehCatAseguradora { get; set; }

        [Required]
        [MaxLength(50)]
        public string StrNumeroPoliza { get; set; } = string.Empty;

        public decimal MnyMontoCoberura { get; set; }

        public int IdVehCatTipoCobertura { get; set; }

        public decimal MnyMontoPagado { get; set; }

        public int IdVehFormaPago { get; set; }

        [MaxLength(2048)]
        public string? StrUrlComprobantePago { get; set; }

        public DateOnly DteFechaInicio { get; set; }

        public DateOnly DteFechaVencimiento { get; set; }

        public int IdVehCatStatus { get; set; }

        [MaxLength(2048)]
        public string? StrUrlPolizaSeguro { get; set; }
    }
}
