namespace Cavex.Principal.API.Dtos.VehDocumentosVehiculo
{
    public class VehDocumentosVehiculoDto
    {
        public int Id { get; set; }
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
    }
}
