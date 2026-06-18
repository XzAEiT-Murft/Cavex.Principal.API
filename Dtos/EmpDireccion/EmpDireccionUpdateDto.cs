using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.EmpDireccion
{
    public class EmpDireccionUpdateDto
    {
        [Required]
        public int IdEmpCatColonia { get; set; }

        public int? IntNumExterior { get; set; }

        public int? IntNumInterior { get; set; }
    }
}
