using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Entities



{
    public class EmpCatNacionalidad : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }
        public EmpCatNacionalidad? EmpNacionalidad { get; set; }

        public List<EmpEmpleado>? EmpEmpleados { get; set; }
    }
}
