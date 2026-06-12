using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Entities
{
    public class EmpTelefono : BaseEntity
    {
        public required string StrNumeroFijo { get; set; }
        public string? StrNumeroCelular { get; set; }
        public int IdEmpEmpleado { get; set; }

        public EmpEmpleado? EmpEmpleado { get; set; }
    }
}

