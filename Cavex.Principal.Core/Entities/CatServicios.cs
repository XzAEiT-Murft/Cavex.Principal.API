using Cavex.Principal.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Entities
{
    public class CatServicios : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }
        public int IdCatStatus { get; set; }

        public CatStatus? CatStatus { get; set; }
    }
}
