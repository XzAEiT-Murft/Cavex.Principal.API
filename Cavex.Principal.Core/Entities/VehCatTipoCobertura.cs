namespace Cavex.Principal.Core.Entities
{
    public class VehCatTipoCobertura : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<VehSeguro>? VehSeguros { get; set; }
    }
}