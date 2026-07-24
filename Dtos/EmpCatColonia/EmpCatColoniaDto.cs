namespace Cavex.Principal.API.Dtos.EmpCatColonia
{
    public class EmpCatColoniaDto
    {
        public int Id { get; set; }
        public string StrValor { get; set; } = string.Empty;
        public string? StrDescripcion { get; set; }
        public int IntCodigoPostal { get; set; }
        public string StrTipoAsentamiento { get; set; } = string.Empty;
        public int IntEmpCatMunicipio { get; set; }
        public string? StrMunicipio { get; set; }
        public string? StrEstado { get; set; }
    }
}
