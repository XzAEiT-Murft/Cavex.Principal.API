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
        public List<EmpCatNacionalidad>? EmpCatNacionalidades { get; set; }
    }
}
