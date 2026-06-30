namespace Cavex.Principal.Core.Specifications.VehCatCapacidad
{
    public class VehCatCapacidadSpecification : BaseSpecification<Entities.VehCatCapacidad>
    {
        public VehCatCapacidadSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatCapacidadSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
