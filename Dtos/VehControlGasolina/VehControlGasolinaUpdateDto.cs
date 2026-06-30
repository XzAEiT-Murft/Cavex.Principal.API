using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehControlGasolina
{
    public class VehControlGasolinaUpdateDto
    {
        public int IdVehDatosGenerales { get; set; }

        public DateOnly DteFechaCarga { get; set; }

        public decimal MnyMontoPagado { get; set; }

        public decimal MnyPrecioLitro { get; set; }

        public decimal DecKilometrajeActual { get; set; }

        public int IdVehFormaPago { get; set; }

        [MaxLength(2048)]
        public string? StrUrlComprobantePago { get; set; }

        public int IdVehCatGasolineras { get; set; }

        public int IdEmpEmpleado { get; set; }
    }
}
