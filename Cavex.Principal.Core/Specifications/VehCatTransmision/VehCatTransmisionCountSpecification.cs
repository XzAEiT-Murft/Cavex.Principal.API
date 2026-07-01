namespace Cavex.Principal.Core.Specifications.VehCatTransmision
{
    /// <summary>
    /// Specification de conteo para transmisiones vehiculares, sin aplicar paginacion.
    /// </summary>
    public class VehCatTransmisionCountSpecification : BaseSpecification<Entities.VehCatTransmision>
    {
        public VehCatTransmisionCountSpecification(string? search)
            : base(x =>
                string.IsNullOrWhiteSpace(search) ||
                x.StrValor.Contains(search) ||
                (x.StrDescripcion != null && x.StrDescripcion.Contains(search)))
        {
        }
    }
}
