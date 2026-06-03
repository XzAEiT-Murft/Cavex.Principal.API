using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Entities
{
    internal class EmpDireccion:BaseEntity
    {
        public int IdEmpCatColonia { get; set; }    
        public int? IntNumExterior { get; set; }    
        public int? IntNumInterior { get; set; }    

        public EmpCatColonia? EmpCatColonia { get; set; }
        public EmpEmpleado? EmpEmpleado { get; set; }
    
}
}
