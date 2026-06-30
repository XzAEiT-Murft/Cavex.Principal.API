namespace Cavex.Principal.Core.Specifications.VehVerificacion
{
    public class VehVerificacionSpecification : BaseSpecification<Entities.VehVerificacion>
    {
        public VehVerificacionSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrFolioVerificacion.Contains(search) || x.StrCentroVerificacion.Contains(search) || x.StrSemestre.Contains(search))
        {
            AddOrderBy(x => x.StrFolioVerificacion);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehVerificacionSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
