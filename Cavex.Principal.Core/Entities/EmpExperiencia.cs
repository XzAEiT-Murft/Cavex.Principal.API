namespace Cavex.Principal.Core.Entities
{
    public class EmpExperiencia:BaseEntity
    {
        public required string StrEmpresa { get; set; }
        public required string StrPuesto { get; set; }
        public required string StrArea { get; set; }
        public DateOnly DteFechaIncio { get; set; }
        public DateOnly DteFechaFin { get; set; }
        public decimal MnySueldo { get; set; }
        public required string StrMotivoSalida { get; set; }
        public int IdEmpEmpleado { get; set; }

        public EmpEmpleado? EmpEmpleado { get; set; }
    }

}
