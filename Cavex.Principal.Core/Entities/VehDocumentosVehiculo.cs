namespace Cavex.Principal.Core.Entities
{
    public class VehDocumentosVehiculo : BaseEntity
    {
        public int IdVehDatosGenerales { get; set; }
        public string? StrUrlFactura { get; set; }
        public int? IdVehTarjetaCirculacion { get; set; }
        public int? IdVehTenencia { get; set; }
        public int? IdVehVerificacion { get; set; }
        public int? IdVehSeguro { get; set; }
        public int? IdVehPermisoTransporte { get; set; }
        public int? IdVehRevistaVehicular { get; set; }
        public int? IdVehContratoArrendamiento { get; set; }
        public int? IdVehPlacas { get; set; }

        public VehDatosGenerales? VehDatosGenerales { get; set; }
        public VehTarjetaCirculacion? VehTarjetaCirculacion { get; set; }
        public VehTenencia? VehTenencia { get; set; }
        public VehVerificacion? VehVerificacion { get; set; }
        public VehSeguro? VehSeguro { get; set; }
        public VehPermisoTransporte? VehPermisoTransporte { get; set; }
        public VehRevistaVehicular? VehRevistaVehicular { get; set; }
        public VehContratoArrendamiento? VehContratoArrendamiento { get; set; }
        public VehPlacas? VehPlacas { get; set; }
    }
}