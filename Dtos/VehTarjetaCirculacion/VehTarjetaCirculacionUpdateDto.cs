using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehTarjetaCirculacion
{
    public class VehTarjetaCirculacionUpdateDto
    {
        public int IdVehDatosGenerales { get; set; }

        [Required]
        [MaxLength(50)]
        public string StrNumeroTarjeta { get; set; } = string.Empty;

        public int IdEmpCatEntidadFederativa { get; set; }

        public DateOnly DteFechaExpedicion { get; set; }

        public DateOnly DteFechaVencimiento { get; set; }

        public int IdVehCatStatus { get; set; }

        public decimal MnyMontoPagado { get; set; }

        public int IdVehFormaPago { get; set; }

        [MaxLength(2048)]
        public string? StrUrlComprobantePago { get; set; }

        [MaxLength(2048)]
        public string? StrUrlTarjeta { get; set; }
    }
}
