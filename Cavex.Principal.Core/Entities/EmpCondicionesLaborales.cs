using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Entities
{
    public class EmpCondicionesLaborales : BaseEntity
    {
        public bool BitCercaniaVivienda { get; set; }
        public bool BitDisponibilidadDeViaje { get; set; }
        public decimal MnySueldoMensual { get; set; }
        public bool BitExperienciaEnArea { get; set; }
        public bool BitDisponibilidadCambioResidencia { get; set; }
        public DateOnly DteFechaIngreso { get; set; }

        public List<EmpEmpleado>? EmpEmpleados { get; set; }
    }
}
