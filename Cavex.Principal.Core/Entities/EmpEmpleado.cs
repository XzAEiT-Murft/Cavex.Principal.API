using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Entities
{
    internal class EmpEmpleado : BaseEntity
    {
        public required string StrNombre { get; set; }
        public required string StrApellidoPaterno { get; set; }
        public string? StrApellidoMaterno { get; set; }
        public DateOnly DteFechaNacimiento { get; set; }
        public required string StrRfc { get; set; }
        public required string StrCurp { get; set; }
        public int IntEdad { get; set; }
        public required string StrCorreoElectronico { get; set; }
        public int IntNss { get; set; }
        public int IdEmpCatGenero { get; set; }
        public int IdEmpCatEstadoCivil { get; set; }
        public int IdEmpCatNacionalidad { get; set; }
        public int IdEmpCatTipoContratacion { get; set; }
        public int IdEmpDireccion { get; set; }
        public int IdEmpDatosAcademicos { get; set; }
        public int IdEmpDocumentosLaborales { get; set; }


        public EmpCatGenero? EmpCatGenero { get; set; }
        public EmpCatEstadoCivil? EmpCatEstadoCivil { get; set; }
        public EmpCatNacionalidad? EmpCatNacionalidad { get; set; }
        public EmpCatTipoContratacion? EmpCatTipoContratacion { get; set; }
        public EmpDireccion? EmpDireccion { get; set; }
        public EmpDatosAcademicos? EmpDatosAcademicos { get; set; }
        public EmpDocumentosLaborales? EmpDocumentosLaborales { get; set; }
        public EmpCondicionesLaborales? EmpCondicionesLaborales { get; set; }

        public List<EmpExperiencia>? EmpExperiencias { get; set; }
        public List<EmpHistorialArea>? EmpHistorialAreas { get; set; }
        public List<EmpReferenciasPersonales>? EmpReferenciasPersonales { get; set; }
        public List<EmpTelefono>? EmpTelefonos { get; set; }
    }
}
