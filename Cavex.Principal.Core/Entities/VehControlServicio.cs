namespace Cavex.Principal.Core.Entities
{
    public class VehControlServicio : BaseEntity
    {
        public int IdVehDatosGenerales { get; set; }
        public int IdVehCatResponsableServicio { get; set; }
        public int IdVehCatStatus { get; set; }
        public string? StrDescripcion { get; set; }
        public int IdEmpEmpleado { get; set; }
        public int IdVehCatTaller { get; set; }
        public DateTime DteFechaInicio { get; set; }
        public long BigKilometrajeActual { get; set; }
        public int? IdVehServicioDetalle { get; set; }

        public VehDatosGenerales? VehDatosGenerales { get; set; }
        public VehCatResponsableServicio? VehCatResponsableServicio { get; set; }
        public VehCatStatus? VehCatStatus { get; set; }
        public EmpEmpleado? EmpEmpleado { get; set; }
        public VehCatTaller? VehCatTaller { get; set; }
        public VehServicioDetalle? VehServicioDetalle { get; set; }
    }
}
