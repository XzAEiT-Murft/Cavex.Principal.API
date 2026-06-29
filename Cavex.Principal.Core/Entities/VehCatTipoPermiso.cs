namespace Cavex.Principal.Core.Entities
{
    public class VehCatTipoPermiso : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<VehPermisoTransporte>? VehPermisosTransporte { get; set; }
    }
}