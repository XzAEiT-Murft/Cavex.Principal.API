namespace Cavex.Principal.Core.Specifications.VehCatResponsableServicio
{
    public class VehCatResponsableServicioSpecification : BaseSpecification<Entities.VehCatResponsableServicio>
    {
        public VehCatResponsableServicioSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatResponsableServicioSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
