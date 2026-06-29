namespace Cavex.Principal.Core.Entities
{
    public class VehRefaccionesUsadas : BaseEntity
    {
        public int IdVehControlServicio { get; set; }
        public int IdVehCatRefacciones { get; set; }

        public VehControlServicio? VehControlServicio { get; set; }
        public VehCatRefacciones? VehCatRefacciones { get; set; }
    }
}