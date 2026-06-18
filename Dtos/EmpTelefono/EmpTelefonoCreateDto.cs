using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.EmpTelefono
{
    public class EmpTelefonoCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string StrNumeroFijo { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? StrNumeroCelular { get; set; }

        [Required]
        public int IdEmpEmpleado { get; set; }
    }
}
