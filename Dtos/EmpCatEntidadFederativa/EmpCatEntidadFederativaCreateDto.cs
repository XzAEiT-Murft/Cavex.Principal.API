using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.EmpCatEntidadFederativa
{
    public class EmpCatEntidadFederativaCreateDto
    {
        [Required]
        [MaxLength(150)]
        public string StrValor { get; set; } = string.Empty;

        [MaxLength(450)]
        public string? StrDescripcion { get; set; }

        [Required]
        public int IdEmpCatPais { get; set; }
    }
}