namespace Cavex.Principal.Core.Specifications.VehDatosGenerales
{
    public class VehDatosGeneralesSpecification : BaseSpecification<Entities.VehDatosGenerales>
    {
        public VehDatosGeneralesSpecification(string? search, int pageIndex, int pageSize)
            : base(x =>
                string.IsNullOrWhiteSpace(search) ||
                x.StrNumSerie.Contains(search) ||
                x.StrModelo.Contains(search) ||
                (x.StrVersion != null && x.StrVersion.Contains(search)) ||
                x.StrPlaca.Contains(search) ||
                (x.StrMotor != null && x.StrMotor.Contains(search)))
        {
            AddOrderBy(x => x.StrNumSerie);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehDatosGeneralesSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
