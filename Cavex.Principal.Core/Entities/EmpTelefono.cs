namespace Cavex.Principal.Core.Entities
{
    public class EmpTelefono : BaseEntity
    {
        public required string StrNumeroFijo { get; set; }
        public string? StrNumeroCelular { get; set; }
        public long BigNumeroFijo { get; set; }
        public long? BigNumeroCelular { get; set; }
        public int IdEmpEmpleado { get; set; }

        public EmpEmpleado? EmpEmpleado { get; set; }
    }
}

