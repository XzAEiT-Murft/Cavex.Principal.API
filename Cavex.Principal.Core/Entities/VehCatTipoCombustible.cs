namespace Cavex.Principal.Core.Entities
{
    public class VehCatTipoCombustible : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<VehDatosGenerales>? VehDatosGenerales { get; set; }
    }
}