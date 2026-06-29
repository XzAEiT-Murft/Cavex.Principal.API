namespace Cavex.Principal.Core.Entities
{
    public class VehCatPosicionLlanta : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<VehControlLlanta>? VehControlesLlanta { get; set; }
    }
}