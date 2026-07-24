namespace Cavex.Principal.Core.Entities
{
    public class VehRefaccionesUsadas : BaseEntity
    {
        public int IdVehServicioDetalle { get; set; }
        public int IdVehCatRefacciones { get; set; }

        public VehServicioDetalle? VehServicioDetalle { get; set; }
        public VehCatRefacciones? VehCatRefacciones { get; set; }
    }
}
