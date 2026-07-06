using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.EmpTelefono
{
    public class EmpTelefonoCreateDto
    {
        [Required]
        public long BigNumeroFijo { get; set; }

        public long? BigNumeroCelular { get; set; }

        [Required]
        public int IdEmpEmpleado { get; set; }
    }
}
