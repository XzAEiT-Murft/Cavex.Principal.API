using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehAsignacionVehiculos
{
    public class VehAsignacionVehiculosCreateDto
    {
        public int IdVehDatosGenerales { get; set; }

        public int IdEmpEmpleado { get; set; }

        public DateOnly DteFechaAsigncion { get; set; }

        public decimal DecKilometrajeInicial { get; set; }

        public decimal? DecKilometrajeFinal { get; set; }

        public decimal? DecKilometrajeTotal { get; set; }
    }
}
