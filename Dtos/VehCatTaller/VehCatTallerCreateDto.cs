using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehCatTaller
{
    public class VehCatTallerCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string StrValor { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? StrDescripcion { get; set; }
        public int IdCatStatus { get; set; } = 1;
    }
}
