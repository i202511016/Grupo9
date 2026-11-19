namespace DSWI_T1_0009.Models
{
    public class MembresiaGimnasioModel
    {
        public int Edad { get; set; }
        public int Meses { get; set; }
        public decimal? TarifaBase { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? TotalPagar { get; set; }
    }
}