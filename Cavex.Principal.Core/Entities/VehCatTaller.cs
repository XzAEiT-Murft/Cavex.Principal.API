namespace Cavex.Principal.Core.Entities
{
    public class VehCatTaller : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }
        public int IdCatStatus { get; set; } = 1;

        public CatStatus? CatStatus { get; set; }
        public List<VehControlServicio>? VehControlesServicio { get; set; }
    }
}