using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpEmpleado
{
    public class EmpEmpleadoSpecification : BaseSpecification<Entities.EmpEmpleado>
    {
        public EmpEmpleadoSpecification(string? search, int pageIndex, int pageSize, int? status = null)
            : base(CreateCriteria(search, status))
        {
            AddOrderBy(x => x.StrApellidoPaterno);

            var skip = (pageIndex - 1) * pageSize;
            ApplyPaging(skip, pageSize);

            AddInclude(x => x.EmpCondicionesLaborales);
            AddInclude(x => x.EmpTelefonos);
            AddInclude(x => x.EmpCatTipoContratacion);
            AddInclude(x => x.CatStatus);
            AddInclude("EmpHistorialAreas.EmpCatAreaLaboral");
        }

        public EmpEmpleadoSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.EmpDireccion);
            AddInclude(x => x.EmpDatosAcademicos);
            AddInclude(x => x.EmpDocumentosLaborales);
            AddInclude(x => x.EmpCondicionesLaborales);
            AddInclude(x => x.EmpExperiencias);
            AddInclude("EmpHistorialAreas.EmpCatAreaLaboral");
            AddInclude(x => x.EmpReferenciasPersonales);
            AddInclude(x => x.EmpTelefonos);
        }

        private static Expression<Func<Entities.EmpEmpleado, bool>> CreateCriteria(string? search, int? status)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return status.HasValue ? (x => x.IdCatStatus == status.Value) : (x => true);
            }

            if (long.TryParse(search, out var searchId))
            {
                return status.HasValue
                    ? (x => (x.Id == searchId ||
                             x.IntEdad == searchId ||
                             x.IntNss == searchId ||
                             x.IdEmpCatGenero == searchId ||
                             x.IdEmpCatEstadoCivil == searchId ||
                             x.IdEmpCatNacionalidad == searchId ||
                             x.IdEmpCatTipoContratacion == searchId ||
                             x.IdEmpDireccion == searchId ||
                             x.IdEmpDatosAcademicos == searchId ||
                             x.IdEmpDocumentosLaborales == searchId ||
                             x.IdEmpCondicionesLaborales == searchId ||
                             x.IdCatStatus == searchId) && x.IdCatStatus == status.Value)
                    : (x => x.Id == searchId ||
                            x.IntEdad == searchId ||
                            x.IntNss == searchId ||
                            x.IdEmpCatGenero == searchId ||
                            x.IdEmpCatEstadoCivil == searchId ||
                            x.IdEmpCatNacionalidad == searchId ||
                            x.IdEmpCatTipoContratacion == searchId ||
                            x.IdEmpDireccion == searchId ||
                            x.IdEmpDatosAcademicos == searchId ||
                            x.IdEmpDocumentosLaborales == searchId ||
                            x.IdEmpCondicionesLaborales == searchId ||
                            x.IdCatStatus == searchId);
            }

            return status.HasValue
                ? (x => (x.StrNombre.Contains(search) ||
                         x.StrApellidoPaterno.Contains(search) ||
                         (x.StrApellidoMaterno != null && x.StrApellidoMaterno.Contains(search)) ||
                         x.StrRfc.Contains(search) ||
                         x.StrCurp.Contains(search) ||
                         x.StrCorreoElectronico.Contains(search)) && x.IdCatStatus == status.Value)
                : (x => x.StrNombre.Contains(search) ||
                        x.StrApellidoPaterno.Contains(search) ||
                        (x.StrApellidoMaterno != null && x.StrApellidoMaterno.Contains(search)) ||
                        x.StrRfc.Contains(search) ||
                        x.StrCurp.Contains(search) ||
                        x.StrCorreoElectronico.Contains(search));
        }
    }
}
