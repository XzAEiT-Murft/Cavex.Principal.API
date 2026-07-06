using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.EmpReferenciasPersonales
{
    public class EmpReferenciasPersonalesUpdateDto
    {
        [Required]
        [MaxLength(200)]
        public string StrNombreCompleto { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string StrParentezco { get; set; } = string.Empty;

        [Required]
        public long BigTelefono { get; set; }

        [Required]
        public int IdEmpEmpleado { get; set; }
    }
}
