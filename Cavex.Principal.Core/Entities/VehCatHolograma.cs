namespace Cavex.Principal.Core.Entities
{
    public class VehCatHolograma : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<VehVerificacion>? VehVerificaciones { get; set; }
    }
}