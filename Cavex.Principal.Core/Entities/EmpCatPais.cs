using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Entities
{
    internal class EmpCatPais:BaseEntity
    {
        public required string StrValor { get; set; }       
        public string? StrDescripcion { get; set; }         

        public List<EmpCatEntidadFederativa>? EmpCatEntidadesFederativas { get; set; }
    }
}
