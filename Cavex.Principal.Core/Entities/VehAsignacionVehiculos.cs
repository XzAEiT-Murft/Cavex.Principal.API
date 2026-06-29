namespace Cavex.Principal.Core.Entities
{
    public class VehAsignacionVehiculos : BaseEntity
    {
        public int IdVehDatosGenerales { get; set; }
        public int IdEmpEmpleado { get; set; }
        public DateOnly DteFechaAsigncion { get; set; }
        public decimal DecKilometrajeInicial { get; set; }
        public decimal? DecKilometrajeFinal { get; set; }
        public decimal? DecKilometrajeTotal { get; set; }

        public VehDatosGenerales? VehDatosGenerales { get; set; }
        public EmpEmpleado? EmpEmpleado { get; set; }
    }
}