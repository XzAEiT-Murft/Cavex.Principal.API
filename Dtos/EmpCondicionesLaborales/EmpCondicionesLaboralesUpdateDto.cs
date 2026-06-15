namespace Cavex.Principal.API.Dtos.EmpCondicionesLaborales
{
    public class EmpCondicionesLaboralesUpdateDto
    {
        public bool BitCercaniaVivienda { get; set; }
        public bool BitDisponibilidadDeViaje { get; set; }
        public decimal MnySueldoMensual { get; set; }
        public bool BitExperienciaEnArea { get; set; }
        public bool BitDisponibilidadCambioResidencia { get; set; }
        public DateOnly DteFechaIngreso { get; set; }
    }
}
