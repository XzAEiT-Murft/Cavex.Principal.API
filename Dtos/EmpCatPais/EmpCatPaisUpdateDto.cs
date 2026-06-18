using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.EmpCatPais
{
    public class EmpCatPaisUpdateDto
    {
        [Required]
        public string StrValor { get; set; } = string.Empty;

        public string? StrDescripcion { get; set; }
    }
}