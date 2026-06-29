namespace Cavex.Principal.Core.Entities
{
    public class VehDaniosAccidentes : BaseEntity
    {
        public int IdVehDatosGenerales { get; set; }
        public int IdEmpEmpleado { get; set; }
        public DateOnly DteFechaEvento { get; set; }
        public required string StrDescripcion { get; set; }
        public string? StrUbicacion { get; set; }
        public decimal? MnyMontoReparacion { get; set; }
        public bool BitCubiertoPorSeguro { get; set; }
        public int? IdVehSeguro { get; set; }
        public int IdVehCatStatus { get; set; }
        public string? StrUrlEvidencia { get; set; }
        public string? StrObservaciones { get; set; }

        public VehDatosGenerales? VehDatosGenerales { get; set; }
        public EmpEmpleado? EmpEmpleado { get; set; }
        public VehSeguro? VehSeguro { get; set; }
        public VehCatStatus? VehCatStatus { get; set; }
    }
}