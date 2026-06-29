namespace Cavex.Principal.Core.Entities
{
    public class VehControlServicio : BaseEntity
    {
        public int IdVehDatosGenerales { get; set; }
        public int IdVehCatTipoServicio { get; set; }
        public DateOnly DteFechaServicio { get; set; }
        public decimal DecKilometrajeActual { get; set; }
        public int IdVehCatTaller { get; set; }
        public string? StrDescripcion { get; set; }
        public decimal MnyCostoManoObra { get; set; }
        public decimal MnyCostoRefacciones { get; set; }
        public decimal? MnyCostoTotal { get; set; }
        public int? IntProximoServicioPorKm { get; set; }
        public DateOnly? DteProximoServicioPorFecha { get; set; }
        public int IdVehFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public int IdVehCatResponsableServicio { get; set; }

        public VehDatosGenerales? VehDatosGenerales { get; set; }
        public VehCatTipoServicio? VehCatTipoServicio { get; set; }
        public VehCatTaller? VehCatTaller { get; set; }
        public VehCatFormaPago? VehFormaPago { get; set; }
        public VehCatResponsableServicio? VehCatResponsableServicio { get; set; }

        public List<VehRefaccionesUsadas>? VehRefaccionesUsadas { get; set; }
    }
}