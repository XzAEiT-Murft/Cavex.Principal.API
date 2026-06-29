namespace Cavex.Principal.Core.Entities
{
    public class VehVerificacion : BaseEntity
    {
        public int IdVehDatosGenerales { get; set; }
        public required string StrFolioVerificacion { get; set; }
        public int IdVehCatHolograma { get; set; }
        public required string StrCentroVerificacion { get; set; }
        public int IntAnio { get; set; }
        public required string StrSemestre { get; set; }
        public DateOnly DteFechaVerificacion { get; set; }
        public DateOnly DteFechaVencimiento { get; set; }
        public int IdVehCatStatus { get; set; }

        public VehDatosGenerales? VehDatosGenerales { get; set; }
        public VehCatHolograma? VehCatHolograma { get; set; }
        public VehCatStatus? VehCatStatus { get; set; }

        public List<VehDocumentosVehiculo>? VehDocumentosVehiculo { get; set; }
    }
}