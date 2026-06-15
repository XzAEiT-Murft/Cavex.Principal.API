namespace Cavex.Principal.Core.Entities
{
    public class EmpCatEntidadFederativa:BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }
        public int IdEmpCatPais { get; set; }

        public EmpCatPais? EmpCatPais { get; set; }
        public List<EmpCatMunicipio>? EmpCatMunicipios { get; set; }
    }
}
