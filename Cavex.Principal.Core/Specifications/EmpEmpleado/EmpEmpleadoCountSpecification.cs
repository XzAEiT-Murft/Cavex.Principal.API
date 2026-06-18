using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpEmpleado
{
    public class EmpEmpleadoCountSpecification : BaseSpecification<Entities.EmpEmpleado>
    {
        public EmpEmpleadoCountSpecification(string? search)
            : base(CreateCriteria(search))
        {
        }

        private static Expression<Func<Entities.EmpEmpleado, bool>> CreateCriteria(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return x => true;

            if (int.TryParse(search, out var searchId))
            {
                return x =>
                    x.Id == searchId ||
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
                    x.IdCatStatus == searchId;
            }

            return x =>
                x.StrNombre.Contains(search) ||
                x.StrApellidoPaterno.Contains(search) ||
                (x.StrApellidoMaterno != null && x.StrApellidoMaterno.Contains(search)) ||
                x.StrRfc.Contains(search) ||
                x.StrCurp.Contains(search) ||
                x.StrCorreoElectronico.Contains(search);
        }
    }
}
