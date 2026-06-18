namespace Cavex.Principal.API.Dtos.EmpReferenciasPersonales
{
    public class EmpReferenciasPersonalesDto
    {
        public int Id { get; set; }
        public string StrNombreCompleto { get; set; } = string.Empty;
        public string StrParentezco { get; set; } = string.Empty;
        public int IntTelefono { get; set; }
        public int IdEmpEmpleado { get; set; }
    }
}
