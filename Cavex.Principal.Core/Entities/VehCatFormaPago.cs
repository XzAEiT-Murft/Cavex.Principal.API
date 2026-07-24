namespace Cavex.Principal.Core.Entities
{
    public class VehCatFormaPago : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<VehContratoArrendamiento>? VehContratosArrendamiento { get; set; }
        public List<VehControlGasolina>? VehControlesGasolina { get; set; }
        public List<VehServicioDetalle>? VehServiciosDetalle { get; set; }
        public List<VehInfracciones>? VehInfracciones { get; set; }
        public List<VehPermisoTransporte>? VehPermisosTransporte { get; set; }
        public List<VehPlacas>? VehPlacas { get; set; }
        public List<VehRevistaVehicular>? VehRevistasVehiculares { get; set; }
        public List<VehSeguro>? VehSeguros { get; set; }
        public List<VehTarjetaCirculacion>? VehTarjetasCirculacion { get; set; }
        public List<VehTenencia>? VehTenencias { get; set; }
    }
}
