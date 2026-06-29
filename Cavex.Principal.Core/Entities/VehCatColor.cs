namespace Cavex.Principal.Core.Entities
{
    public class VehCatColor : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<VehDatosGenerales>? VehDatosGenerales { get; set; }
    }
}