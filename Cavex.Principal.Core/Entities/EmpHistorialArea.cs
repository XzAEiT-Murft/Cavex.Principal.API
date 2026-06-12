namespace Cavex.Principal.Core.Entities
{
    public class EmpHistorialArea : BaseEntity
    {
        public int IdEmpCatAreaLaboral { get; set; }
        public int IdEmpEmpleado { get; set; }
        public DateOnly DteFechaInicio { get; set; }
        public DateOnly DteFechaFin { get; set; }

        public EmpCatAreaLaboral? EmpCatAreaLaboral { get; set; }
        public EmpEmpleado? EmpEmpleado { get; set; }
    }
}
