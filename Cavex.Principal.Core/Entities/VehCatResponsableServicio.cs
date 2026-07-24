namespace Cavex.Principal.Core.Entities
{
    public class VehCatResponsableServicio : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }
        public int IdVehCatStatus { get; set; } = 1;

        public List<VehControlServicio>? VehControlesServicio { get; set; }
    }
}