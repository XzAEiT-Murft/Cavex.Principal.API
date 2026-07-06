namespace Cavex.Principal.API.Dtos.EmpEmpleado
{
    public class EmpEmpleadoDto
    {
        public int Id { get; set; }
        public string StrNombre { get; set; } = string.Empty;
        public string StrApellidoPaterno { get; set; } = string.Empty;
        public string? StrApellidoMaterno { get; set; }
        public DateOnly DteFechaNacimiento { get; set; }
        public string StrRfc { get; set; } = string.Empty;
        public string StrCurp { get; set; } = string.Empty;
        public int IntEdad { get; set; }
        public string StrCorreoElectronico { get; set; } = string.Empty;
        public long BigNss { get; set; }
        public int IdEmpCatGenero { get; set; }
        public int IdEmpCatEstadoCivil { get; set; }
        public int IdEmpCatNacionalidad { get; set; }
        public int IdEmpCatTipoContratacion { get; set; }
        public int IdEmpDireccion { get; set; }
        public int IdEmpDatosAcademicos { get; set; }
        public int IdEmpDocumentosLaborales { get; set; }
        public int IdEmpCondicionesLaborales { get; set; }
        public int IdCatStatus { get; set; }
    }
}
