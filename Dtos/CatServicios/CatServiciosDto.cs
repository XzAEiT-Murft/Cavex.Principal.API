namespace Cavex.Principal.API.Dtos.CatServicios
{
    public class CatServiciosDto
    {
        public int Id { get; set; }
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }
        public int IdCatStatus { get; set; }
    }
}
