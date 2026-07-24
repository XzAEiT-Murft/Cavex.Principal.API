namespace Cavex.Principal.Core.Entities
{
    public class VehCatTipoServicio : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<VehServicioDetalle>? VehServiciosDetalle { get; set; }
    }
}
