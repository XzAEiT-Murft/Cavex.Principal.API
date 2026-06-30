using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehTenencia
{
    public class VehTenenciaUpdateDto
    {
        public int IdVehDatosGenerales { get; set; }

        public int IntAnio { get; set; }

        public DateOnly DteFechaPago { get; set; }

        public DateOnly DteFechaVencimiento { get; set; }

        public decimal MnyMontoPagado { get; set; }

        [MaxLength(100)]
        public string? StrFolioPago { get; set; }

        public int IdVehCatFormaPago { get; set; }

        public int IdVehCatStatus { get; set; }

        [MaxLength(2048)]
        public string? StrUrlComprobantePago { get; set; }

        [MaxLength(2048)]
        public string? StrUrlFormatoTenencia { get; set; }
    }
}
