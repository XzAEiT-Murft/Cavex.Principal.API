namespace Cavex.Principal.API.Dtos.EmpTelefono
{
    public class EmpTelefonoDto
    {
        public int Id { get; set; }
        public long BigNumeroFijo { get; set; }
        public long? BigNumeroCelular { get; set; }
        public int IdEmpEmpleado { get; set; }
    }
}
