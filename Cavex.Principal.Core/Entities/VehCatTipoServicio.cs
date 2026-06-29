namespace Cavex.Principal.Core.Entities
{
    public class VehCatTipoServicio : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<VehControlServicio>? VehControlesServicio { get; set; }
    }
}