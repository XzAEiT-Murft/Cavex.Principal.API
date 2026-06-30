namespace Cavex.Principal.API.Dtos.VehControlLlanta
{
    public class VehControlLlantaDto
    {
        public int Id { get; set; }
        public int IdVehDatosGenerales { get; set; }
        public int IdVehCatMarcaLlanta { get; set; }
        public string StrModelo { get; set; } = string.Empty;
        public string StrMedida { get; set; } = string.Empty;
        public DateOnly DteFechaCompra { get; set; }
        public decimal MnyCosto { get; set; }
        public int IdVehCatPosicionLlanta { get; set; }
        public decimal DecKilometrajeActual { get; set; }
        public DateOnly? DteFechaFinVidaEstimada { get; set; }
        public DateOnly? DteFechaRotacion { get; set; }
        public DateOnly? DteFechaSiguienteRotacion { get; set; }
        public string? StrUrlEvidencia { get; set; }
        public int IdVehCatStatus { get; set; }
    }
}
