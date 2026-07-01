using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehCatTransmision
{
    /// <summary>
    /// Contrato para crear una transmision vehicular.
    /// </summary>
    public class VehCatTransmisionCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string StrValor { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? StrDescripcion { get; set; }
    }
}
