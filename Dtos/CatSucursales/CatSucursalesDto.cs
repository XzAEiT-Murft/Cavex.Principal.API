namespace Cavex.Principal.API.Dtos.CatSucursales
{
    public class CatSucursalesDto
    {
        public int Id { get; set; }
        public string StrValor { get; set; } = string.Empty;
        public string? StrDescripcion { get; set; }
        public int IdCatStatus { get; set; }
    }
}
