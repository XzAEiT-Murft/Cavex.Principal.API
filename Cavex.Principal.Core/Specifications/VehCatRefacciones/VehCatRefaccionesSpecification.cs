namespace Cavex.Principal.Core.Specifications.VehCatRefacciones
{
    public class VehCatRefaccionesSpecification : BaseSpecification<Entities.VehCatRefacciones>
    {
        public VehCatRefaccionesSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatRefaccionesSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
