namespace Cavex.Principal.API.Dtos.EmpTelefono
{
    public class EmpTelefonoDto
    {
        public int Id { get; set; }
        public long BigNumeroFijo { get; set; }
        public long? BigNumeroCelular { get; set; }
        public string StrNumeroFijo { get; set; } = string.Empty;
        public string? StrNumeroCelular { get; set; }
        public int IdEmpEmpleado { get; set; }
    }
}
