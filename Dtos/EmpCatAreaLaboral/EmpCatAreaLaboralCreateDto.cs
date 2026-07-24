using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.EmpCatAreaLaboral
{
    /// <summary>
    /// Datos requeridos para crear un area laboral.
    /// </summary>
    public class EmpCatAreaLaboralCreateDto
    {
        /// <summary>
        /// Nombre o valor principal del area laboral.
        /// </summary>
        /// <example>Contabilidad</example>
        [Required]
        [MaxLength(150)]
        public string StrValor { get; set; } = string.Empty;

        /// <summary>
        /// Descripcion opcional del area laboral.
        /// </summary>
        /// <example>Area responsable de registros contables y financieros.</example>
        [MaxLength(450)]
        public string? StrDescripcion { get; set; }

        /// <summary>
        /// Identificador del estatus.
        /// </summary>
        /// <example>1</example>
        public int IdCatStatus { get; set; } = 1;
    }

}
