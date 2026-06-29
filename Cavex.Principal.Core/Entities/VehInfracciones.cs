namespace Cavex.Principal.Core.Entities
{
    public class VehInfracciones : BaseEntity
    {
        public int IdVehDatosGenerales { get; set; }
        public int IdEmpEmpleado { get; set; }
        public DateOnly DteFechaInfraccion { get; set; }
        public required string StrMotivo { get; set; }
        public decimal? MnyMontoPagado { get; set; }
        public int IdVehCatStatus { get; set; }
        public DateOnly? DteFechaPago { get; set; }
        public int? IdVehFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public string? StrObservaciones { get; set; }

        public VehDatosGenerales? VehDatosGenerales { get; set; }
        public EmpEmpleado? EmpEmpleado { get; set; }
        public VehCatStatus? VehCatStatus { get; set; }
        public VehCatFormaPago? VehFormaPago { get; set; }
    }
}