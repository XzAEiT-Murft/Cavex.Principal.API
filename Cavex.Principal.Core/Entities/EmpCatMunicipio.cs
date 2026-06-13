namespace Cavex.Principal.Core.Entities
{
    public class EmpCatMunicipio : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }
        public int IdEmpCatEntidadFederativa { get; set; }

        public EmpCatEntidadFederativa? EmpCatEntidadFederativa { get; set; }
        public List<EmpCatColonia>? EmpCatColonias { get; set; }
    }
}
