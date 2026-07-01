using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehCatTransmision
{
    /// <summary>
    /// Contrato para actualizar una transmision vehicular.
    /// </summary>
    public class VehCatTransmisionUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string StrValor { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? StrDescripcion { get; set; }
    }
}
