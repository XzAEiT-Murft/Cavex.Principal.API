using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.EmpCatColonia
{
    public class EmpCatColoniaUpdateDto
    {
        [Required]
        [MaxLength(150)]
        public string StrValor { get; set; } = string.Empty;

        [MaxLength(450)]
        public string? StrDescripcion { get; set; }

        [Required]
        public int IntCodigoPostal { get; set; }

        [Required]
        [MaxLength(100)]
        public string StrTipoAsentamiento { get; set; } = string.Empty;

        [Required]
        public int IntEmpCatMunicipio { get; set; }
    }
}
