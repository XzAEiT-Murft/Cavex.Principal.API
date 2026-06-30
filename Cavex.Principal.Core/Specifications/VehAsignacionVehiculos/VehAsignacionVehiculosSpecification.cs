namespace Cavex.Principal.Core.Specifications.VehAsignacionVehiculos
{
    public class VehAsignacionVehiculosSpecification : BaseSpecification<Entities.VehAsignacionVehiculos>
    {
        public VehAsignacionVehiculosSpecification(string? search, int pageIndex, int pageSize)
            : base(x => true)
        {
            AddOrderBy(x => x.Id);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehAsignacionVehiculosSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
