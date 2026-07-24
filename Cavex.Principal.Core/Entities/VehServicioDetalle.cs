namespace Cavex.Principal.Core.Entities
{
    public class VehServicioDetalle : BaseEntity
    {
        public int IdVehCatTipoServicio { get; set; }
        public decimal? MnyCostoManoObra { get; set; }
        public decimal? MnyCostoRefacciones { get; set; }
        public decimal? MnyCostoTotal { get; private set; }
        public DateTime DteFechaFin { get; set; }
        public long? BigProximoServicioKm { get; set; }
        public DateOnly? DateProximoServicioFecha { get; set; }
        public int IdVehCatFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public string? StrDescripcion { get; set; }

        public VehCatTipoServicio? VehCatTipoServicio { get; set; }
        public VehCatFormaPago? VehCatFormaPago { get; set; }
        public List<VehControlServicio>? VehControlesServicio { get; set; }
        public List<VehRefaccionesUsadas>? VehRefaccionesUsadas { get; set; }
    }
}
