namespace Cavex.Principal.API.Dtos.EmpHistorialArea
{
    public class EmpHistorialAreaDto
    {
        public int Id { get; set; }
        public int IdEmpCatAreaLaboral { get; set; }
        public int IdEmpEmpleado { get; set; }
        public DateOnly DteFechaInicio { get; set; }
        public DateOnly DteFechaFin { get; set; }
    }
}
