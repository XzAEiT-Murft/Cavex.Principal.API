using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.API.Dtos.CatStatus
{
    public class CatStatusDto
    {
        public int Id { get; set; }
        public string StrValor { get; set; } = string.Empty;
        public string? StrDescripcion { get; set; }
    }
}
