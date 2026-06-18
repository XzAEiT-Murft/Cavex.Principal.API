using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.EmpCondicionesLaborales
{
    public class EmpCondicionesLaboralesCreateDto
    {
        [Required]
        public bool BitCercaniaVivienda { get; set; }

        [Required]
        public bool BitDisponibilidadDeViaje { get; set; }

        [Required]
        public decimal MnySueldoMensual { get; set; }

        [Required]
        public bool BitExperienciaEnArea { get; set; }

        [Required]
        public bool BitDisponibilidadCambioResidencia { get; set; }

        [Required]
        public DateOnly DteFechaIngreso { get; set; }
    }
}
