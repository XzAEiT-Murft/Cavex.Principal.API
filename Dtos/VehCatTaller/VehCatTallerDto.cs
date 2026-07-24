namespace Cavex.Principal.API.Dtos.VehCatTaller
{
    public class VehCatTallerDto
    {
        public int Id { get; set; }
        public string StrValor { get; set; } = string.Empty;
        public string? StrDescripcion { get; set; }
        public int IdCatStatus { get; set; }
    }
}
