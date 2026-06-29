namespace Cavex.Principal.Core.Entities
{
    public class VehCatArrendatario : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<VehContratoArrendamiento>? VehContratosArrendamiento { get; set; }
    }
}