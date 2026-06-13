using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.CatServicios
{
    public class CatServiciosCreateDto
    {

        [Required]
        [MaxLength(150)]
        public string StrValor { get; set; } = string.Empty;

        [MaxLength(450)]
        public string? StrDescripcion { get; set; }

        [Required]
        public int IdCatStatus { get; set; }
    }
}
