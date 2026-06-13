namespace Cavex.Principal.Core.Entities
{
    public class EmpCatPais:BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<EmpCatEntidadFederativa>? EmpCatEntidadesFederativas { get; set; }
    }
}
