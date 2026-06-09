using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Entities
{
    public class EmpDatosAcademicos:BaseEntity
    {
        public required string StrNivelEstudios { get; set; }  
        public required string StrInstitucion { get; set; }     
        public required string StrCarrera { get; set; }         
        public required string StrEstatus { get; set; }        
        public DateOnly DteFechaInicio { get; set; }            
        public DateOnly DteFechaFin { get; set; }               

        public EmpEmpleado? EmpEmpleado { get; set; }
    }
}
