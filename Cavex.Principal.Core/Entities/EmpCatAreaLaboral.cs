namespace Cavex.Principal.Core.Entities
{
    public class EmpCatAreaLaboral:BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<EmpHistorialArea>? EmpHistorialAreas { get; set; }
    }
}

