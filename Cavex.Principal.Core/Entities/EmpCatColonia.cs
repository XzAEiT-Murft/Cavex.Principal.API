using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Entities
{
    internal class EmpCatColonia:BaseEntity
    {
        public required string StrValor { get; set; }       
        public string? StrDescripcion { get; set; }         
        public int? IntCodigoPostal { get; set; }           
        public string? StrTipoAsentamiento { get; set; }    
        public int IdEmpCatEntidadFederativa { get; set; }  

        public EmpCatEntidadFederativa? EmpCatEntidadFederativa { get; set; }
        public List<EmpDireccion>? EmpDirecciones { get; set; }
    }
}
