using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Entities
{
    internal class EmpDocumentosLaborales : BaseEntity
    {
        public required string StrUrlIdentificacionOficial { get; set; }    
        public required string StrUrlComprobanteDomicilio { get; set; }     
        public required string StrUrlCurriculumVitae { get; set; }          
        public required string StrUrlContrato { get; set; }                 
        public required string StrUrlLicencia { get; set; }                 

        public EmpEmpleado? EmpEmpleado { get; set; }
    }
}
