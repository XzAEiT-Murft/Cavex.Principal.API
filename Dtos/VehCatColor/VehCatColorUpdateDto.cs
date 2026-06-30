using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehCatColor
{
    public class VehCatColorUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string StrValor { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? StrDescripcion { get; set; }
    }
}
