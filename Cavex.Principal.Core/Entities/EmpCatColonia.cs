namespace Cavex.Principal.Core.Entities
{
    public class EmpCatColonia:BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }
        public int IntCodigoPostal { get; set; }
        public required string StrTipoAsentamiento { get; set; }
        public int IntEmpCatMunicipio { get; set; }

        public EmpCatMunicipio? EmpCatMunicipio { get; set; }
        public List<EmpDireccion>? EmpDirecciones { get; set; }
    }
}
