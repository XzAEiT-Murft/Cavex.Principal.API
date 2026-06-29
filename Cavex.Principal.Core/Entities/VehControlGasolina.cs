namespace Cavex.Principal.Core.Entities
{
    public class VehControlGasolina : BaseEntity
    {
        public int IdVehDatosGenerales { get; set; }
        public DateOnly DteFechaCarga { get; set; }
        public decimal MnyMontoPagado { get; set; }
        public decimal MnyPrecioLitro { get; set; }
        public decimal DecKilometrajeActual { get; set; }
        public int IdVehFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public int IdVehCatGasolineras { get; set; }
        public int IdEmpEmpleado { get; set; }

        public VehDatosGenerales? VehDatosGenerales { get; set; }
        public VehCatFormaPago? VehFormaPago { get; set; }
        public VehCatGasolineras? VehCatGasolineras { get; set; }
        public EmpEmpleado? EmpEmpleado { get; set; }
    }
}