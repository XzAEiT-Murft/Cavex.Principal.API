using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehCatTipoPermiso
{
    public class VehCatTipoPermisoUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string StrValor { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? StrDescripcion { get; set; }
    }
}
