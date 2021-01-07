
namespace VisaNetHttp.Sales
{
    public class Sale
    {
        public string transaction_type { get; set; } //example: SALE // tipo de transaccion, puede ser SALE, VOID o SETTLEMENT
        public string amount { get; set; } //example: 000000010000", // monto de la transaccion
        public string itbis { get; set; } //example: 000000001600", // Porcentaje del itbis
        public string other_taxes { get; set; }  //example: 000000000040" // Porcentaje de otros impuestos
    }
}
