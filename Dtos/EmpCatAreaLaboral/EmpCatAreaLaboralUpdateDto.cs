using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.EmpCatAreaLaboral
{
    /// <summary>
    /// Datos requeridos para actualizar un area laboral existente.
    /// </summary>
    public class EmpCatAreaLaboralUpdateDto
    {
        /// <summary>
        /// Identificador unico del area laboral.
        /// </summary>
        /// <example>1</example>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Nombre o valor principal actualizado del area laboral.
        /// </summary>
        /// <example>Capital Humano</example>
        [Required]
        [MaxLength(150)]
        public string StrValor { get; set; } = string.Empty;

        /// <summary>
        /// Descripcion actualizada del area laboral.
        /// </summary>
        /// <example>Area responsable de administracion y desarrollo de talento.</example>
        [MaxLength(450)]
        public string? StrDescripcion { get; set; }
    }
}
