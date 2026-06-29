namespace Cavex.Principal.Core.Entities
{
    public class VehCatGasolineras : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<VehControlGasolina>? VehControlesGasolina { get; set; }
    }
}