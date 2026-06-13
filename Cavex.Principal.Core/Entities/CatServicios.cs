namespace Cavex.Principal.Core.Entities
{
    public class CatServicios : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }
        public int IdCatStatus { get; set; }

        public CatStatus? CatStatus { get; set; }
    }
}
