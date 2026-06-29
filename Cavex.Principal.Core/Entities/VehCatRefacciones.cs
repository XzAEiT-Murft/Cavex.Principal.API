namespace Cavex.Principal.Core.Entities
{
    public class VehCatRefacciones : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<VehRefaccionesUsadas>? VehRefaccionesUsadas { get; set; }
    }
}