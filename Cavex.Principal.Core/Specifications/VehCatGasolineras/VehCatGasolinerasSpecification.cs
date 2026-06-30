namespace Cavex.Principal.Core.Specifications.VehCatGasolineras
{
    public class VehCatGasolinerasSpecification : BaseSpecification<Entities.VehCatGasolineras>
    {
        public VehCatGasolinerasSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatGasolinerasSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
