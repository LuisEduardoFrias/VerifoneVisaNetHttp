
namespace VisaNetHttp.Annulments
{
    public class Annulment
    {
        public string transaction_type { get; set; } //example: VOID // Tipo de transaccion
        public string host { get; set; } //example: 01 // host de la transaccion, 01 = VISA, 02 = MASTERCARD
        public string reference { get; set; } //example: 000004 // Ticket number
    }
}
