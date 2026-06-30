namespace Cavex.Principal.Core.Specifications.VehRefaccionesUsadas
{
    public class VehRefaccionesUsadasSpecification : BaseSpecification<Entities.VehRefaccionesUsadas>
    {
        public VehRefaccionesUsadasSpecification(string? search, int pageIndex, int pageSize)
            : base(x => true)
        {
            AddOrderBy(x => x.Id);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehRefaccionesUsadasSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
