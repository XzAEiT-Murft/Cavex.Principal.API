using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Entities
{
    public class EmpCatMunicipio : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }
        public int IdEmpCatEntidadFederativa { get; set; }

        public EmpCatEntidadFederativa? EmpCatEntidadFederativa { get; set; }
        public List<EmpCatColonia>? EmpCatColonias { get; set; }
    }
}
