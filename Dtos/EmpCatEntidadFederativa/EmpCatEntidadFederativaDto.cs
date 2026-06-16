namespace Cavex.Principal.API.Dtos.EmpCatEntidadFederativa
{
    public class EmpCatEntidadFederativaDto
    {
        public int Id { get; set; }

        public string StrValor { get; set; } = string.Empty;

        public string? StrDescripcion { get; set; }

        public int IdEmpCatPais { get; set; }
    }
}