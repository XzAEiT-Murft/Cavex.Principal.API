using Cavex.Principal.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cavex.Principal.API
{
    public class CatStatus : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<CatServicios>? CatServicios { get; set; }
        public List<CatSucursales>? CatSucursales { get; set; }
        public List<EmpEmpleado>? EmpEmpleados { get; set; }
    }
}
