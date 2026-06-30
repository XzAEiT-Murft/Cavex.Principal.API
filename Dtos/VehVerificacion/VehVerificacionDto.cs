namespace Cavex.Principal.API.Dtos.VehVerificacion
{
    public class VehVerificacionDto
    {
        public int Id { get; set; }
        public int IdVehDatosGenerales { get; set; }
        public string StrFolioVerificacion { get; set; } = string.Empty;
        public int IdVehCatHolograma { get; set; }
        public string StrCentroVerificacion { get; set; } = string.Empty;
        public int IntAnio { get; set; }
        public string StrSemestre { get; set; } = string.Empty;
        public DateOnly DteFechaVerificacion { get; set; }
        public DateOnly DteFechaVencimiento { get; set; }
        public int IdVehCatStatus { get; set; }
    }
}
