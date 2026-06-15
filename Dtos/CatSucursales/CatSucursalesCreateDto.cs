namespace Cavex.Principal.API.Dtos.CatSucursales
{
    public class CatSucursalesCreateDto
    {
        public string StrValor { get; set; } = string.Empty;
        public string? StrDescripcion { get; set; }
        public int IdCatStatus { get; set; }
    }
}
