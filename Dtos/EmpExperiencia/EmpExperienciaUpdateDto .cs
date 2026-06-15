namespace Cavex.Principal.API.Dtos.EmpExperiencia
{
    public class EmpExperienciaUpdateDto
    {
        public string StrEmpresa { get; set; } = string.Empty;
        public string StrPuesto { get; set; } = string.Empty;
        public string StrArea { get; set; } = string.Empty;
        public DateOnly DteFechaIncio { get; set; }
        public DateOnly DteFechaFin { get; set; }
        public decimal MnySueldo { get; set; }
        public string StrMotivoSalida { get; set; } = string.Empty;
        public int IdEmpEmpleado { get; set; }
    }
}
