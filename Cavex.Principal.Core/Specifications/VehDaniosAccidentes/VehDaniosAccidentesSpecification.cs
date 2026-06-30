namespace Cavex.Principal.Core.Specifications.VehDaniosAccidentes
{
    public class VehDaniosAccidentesSpecification : BaseSpecification<Entities.VehDaniosAccidentes>
    {
        public VehDaniosAccidentesSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrDescripcion.Contains(search) || x.StrUbicacion.Contains(search) || x.StrUrlEvidencia.Contains(search) || x.StrObservaciones.Contains(search))
        {
            AddOrderBy(x => x.StrDescripcion);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehDaniosAccidentesSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
