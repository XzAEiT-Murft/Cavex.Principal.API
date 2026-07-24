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
        public long IntNss { get; set; }
        public int IdEmpCatGenero { get; set; }
        public int IdEmpCatEstadoCivil { get; set; }
        public int IdEmpCatNacionalidad { get; set; }
        public int IdEmpCatTipoContratacion { get; set; }
        public int IdEmpDireccion { get; set; }
        public int IdEmpDatosAcademicos { get; set; }
        public int IdEmpDocumentosLaborales { get; set; }
        public int IdEmpCondicionesLaborales { get; set; }
        public int IdCatStatus { get; set; }

        public string StrEmpCatGenero { get; set; } = string.Empty;
        public string StrEmpCatEstadoCivil { get; set; } = string.Empty;
        public string StrEmpCatNacionalidad { get; set; } = string.Empty;
        public string StrEmpCatTipoContratacion { get; set; } = string.Empty;
        public string StrEmpDireccion { get; set; } = string.Empty;
        public string StrEmpDatosAcademicos { get; set; } = string.Empty;
        public string StrEmpDocumentosLaborales { get; set; } = string.Empty;
        public string StrEmpCondicionesLaborales { get; set; } = string.Empty;
        public string StrCatStatus { get; set; } = string.Empty;

        public Cavex.Principal.API.Dtos.EmpDireccion.EmpDireccionDto? EmpDireccion { get; set; }
        public Cavex.Principal.API.Dtos.EmpDatosAcademicos.EmpDatosAcademicosDto? EmpDatosAcademicos { get; set; }
        public Cavex.Principal.API.Dtos.EmpDocumentosLaborales.EmpDocumentosLaboralesDto? EmpDocumentosLaborales { get; set; }
        public Cavex.Principal.API.Dtos.EmpCondicionesLaborales.EmpCondicionesLaboralesDto? EmpCondicionesLaborales { get; set; }

        public System.Collections.Generic.List<Cavex.Principal.API.Dtos.EmpExperiencia.EmpExperienciaDto>? EmpExperiencias { get; set; }
        public System.Collections.Generic.List<Cavex.Principal.API.Dtos.EmpHistorialArea.EmpHistorialAreaDto>? EmpHistorialAreas { get; set; }
        public System.Collections.Generic.List<Cavex.Principal.API.Dtos.EmpReferenciasPersonales.EmpReferenciasPersonalesDto>? EmpReferenciasPersonales { get; set; }
        public System.Collections.Generic.List<Cavex.Principal.API.Dtos.EmpTelefono.EmpTelefonoDto>? EmpTelefonos { get; set; }
    }
}
