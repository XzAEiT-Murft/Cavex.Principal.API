using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Entities
{
    public class EmpCatEntidadFederativa:BaseEntity
    {
        public required string StrValor { get; set; }      
        public string? StrDescripcion { get; set; }        
        public int IdEmpCatPais { get; set; }              

        public EmpCatPais? EmpCatPais { get; set; }
        public List<EmpCatColonia>? EmpCatColonias { get; set; }
    }
}
