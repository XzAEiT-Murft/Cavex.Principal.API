namespace Cavex.Principal.API.Dtos.VehAsignacionVehiculos
{
    public class VehAsignacionVehiculosDto
    {
        public int Id { get; set; }
        public int IdVehDatosGenerales { get; set; }
        public int IdEmpEmpleado { get; set; }
        public DateOnly DteFechaAsigncion { get; set; }
        public decimal DecKilometrajeInicial { get; set; }
        public decimal? DecKilometrajeFinal { get; set; }
        public decimal? DecKilometrajeTotal { get; set; }
    }
}
