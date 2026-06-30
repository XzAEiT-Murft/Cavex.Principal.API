using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehRefaccionesUsadas
{
    public class VehRefaccionesUsadasUpdateDto
    {
        public int IdVehControlServicio { get; set; }

        public int IdVehCatRefacciones { get; set; }
    }
}
