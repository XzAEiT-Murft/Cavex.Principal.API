using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehCatAseguradora
{
    public class VehCatAseguradoraUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string StrValor { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? StrDescripcion { get; set; }
    }
}
