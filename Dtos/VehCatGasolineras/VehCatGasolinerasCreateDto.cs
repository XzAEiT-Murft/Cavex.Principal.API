using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehCatGasolineras
{
    public class VehCatGasolinerasCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string StrValor { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? StrDescripcion { get; set; }
    }
}
