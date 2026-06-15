namespace Cavex.Principal.Core.Entities
{
    public class EmpCatNacionalidad : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<EmpEmpleado>? EmpEmpleados { get; set; }
    }
}
