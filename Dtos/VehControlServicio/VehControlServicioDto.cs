namespace Cavex.Principal.API.Dtos.VehControlServicio
{
    public class VehControlServicioDto
    {
        public int Id { get; set; }
        public int IdVehDatosGenerales { get; set; }
        public int IdVehCatTipoServicio { get; set; }
        public DateOnly DteFechaServicio { get; set; }
        public DateTime DteFechaInicio { get; set; }
        public DateTime? DteFechaFin { get; set; }
        public decimal DecKilometrajeActual { get; set; }
        public int IdVehCatTaller { get; set; }
        public string? StrDescripcion { get; set; }
        public decimal? MnyCostoManoObra { get; set; }
        public decimal? MnyCostoRefacciones { get; set; }
        public decimal? MnyCostoTotal { get; set; }
        public int? IntProximoServicioPorKm { get; set; }
        public DateOnly? DteProximoServicioPorFecha { get; set; }
        public int IdVehFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public int IdVehCatResponsableServicio { get; set; }
        public int IdVehCatStatus { get; set; }
        public int IdEmpEmpleado { get; set; }
        public int? IdVehServicioDetalle { get; set; }
    }
}
