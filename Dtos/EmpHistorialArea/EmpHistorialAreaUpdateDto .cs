using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.EmpHistorialArea
{
    public class EmpHistorialAreaUpdateDto
    {
        [Required]
        public int IdEmpCatAreaLaboral { get; set; }

        [Required]
        public int IdEmpEmpleado { get; set; }

        [Required]
        public DateOnly DteFechaInicio { get; set; }

        [Required]
        public DateOnly DteFechaFin { get; set; }
    }

}
