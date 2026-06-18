namespace Cavex.Principal.API.Dtos.EmpDireccion
{
    public class EmpDireccionDto
    {
        public int Id { get; set; }
        public int IdEmpCatColonia { get; set; }
        public int? IntNumExterior { get; set; }
        public int? IntNumInterior { get; set; }
    }
}