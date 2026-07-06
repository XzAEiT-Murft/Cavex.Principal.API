using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Entities
{
    public class EmpReferenciasPersonales : BaseEntity
    {
        public required string StrNombreCompleto { get; set; }
        public required string StrParentezco { get; set; }
        public long IntTelefono { get; set; }
        public long BigTelefono { get; set; }
        public int IdEmpEmpleado { get; set; }

        public EmpEmpleado? EmpEmpleado { get; set; }
    }
}
