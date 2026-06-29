namespace Cavex.Principal.Core.Entities
{
    public class VehControlLlanta : BaseEntity
    {
        public int IdVehDatosGenerales { get; set; }
        public int IdVehCatMarcaLlanta { get; set; }
        public required string StrModelo { get; set; }
        public required string StrMedida { get; set; }
        public DateOnly DteFechaCompra { get; set; }
        public decimal MnyCosto { get; set; }
        public int IdVehCatPosicionLlanta { get; set; }
        public decimal DecKilometrajeActual { get; set; }
        public DateOnly? DteFechaFinVidaEstimada { get; set; }
        public DateOnly? DteFechaRotacion { get; set; }
        public DateOnly? DteFechaSiguienteRotacion { get; set; }
        public string? StrUrlEvidencia { get; set; }
        public int IdVehCatStatus { get; set; }

        public VehDatosGenerales? VehDatosGenerales { get; set; }
        public VehCatMarcaLlanta? VehCatMarcaLlanta { get; set; }
        public VehCatPosicionLlanta? VehCatPosicionLlanta { get; set; }
        public VehCatStatus? VehCatStatus { get; set; }
    }
}