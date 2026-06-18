using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.EmpEmpleado
{
    public class EmpEmpleadoCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string StrNombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string StrApellidoPaterno { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? StrApellidoMaterno { get; set; }

        [Required]
        public DateOnly DteFechaNacimiento { get; set; }

        [Required]
        [MaxLength(50)]
        public string StrRfc { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string StrCurp { get; set; } = string.Empty;

        [Required]
        public int IntEdad { get; set; }

        [Required]
        [MaxLength(100)]
        public string StrCorreoElectronico { get; set; } = string.Empty;

        [Required]
        public int IntNss { get; set; }

        [Required]
        public int IdEmpCatGenero { get; set; }

        [Required]
        public int IdEmpCatEstadoCivil { get; set; }

        [Required]
        public int IdEmpCatNacionalidad { get; set; }

        [Required]
        public int IdEmpCatTipoContratacion { get; set; }

        [Required]
        public int IdEmpDireccion { get; set; }

        [Required]
        public int IdEmpDatosAcademicos { get; set; }

        [Required]
        public int IdEmpDocumentosLaborales { get; set; }

        [Required]
        public int IdEmpCondicionesLaborales { get; set; }

        [Required]
        public int IdCatStatus { get; set; }
    }
}
