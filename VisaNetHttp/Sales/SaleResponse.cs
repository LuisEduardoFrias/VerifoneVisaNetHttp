
namespace VisaNetHttp.Sales
{
    public class SaleResponse : Exceptions
    {
        public string terminal_id { get; set; } //example: 00006575 // terminal asignado por VISANET
        public string host { get; set; } //example: 01 // id del host, 01 = VISA, 02 = MASTERCARD
        public string signed { get; set; } //example: NOT_SIGNED // firma
        public string authorization { get; set; } //example: 881343 // Numero de aprobacion
        public string aid { get; set; } //example: A0000000031010 // aid
        public string cardholder_name { get; set; } //example:  / // Nombre de tarjeta habiente
        public string date { get; set; } //example: 301120 // fecha en formato DDMMYY
        public string ticket_number { get; set; } //example: 000002 // Ticket number(este campo corresponde a la referencia de la anulacion)
        public string version { get; set; } //example: NEWPOS 5210 ECRT V1.0 // version
        public string reference_number { get; set; } //example: 033513082911 // Numero de referencia
        public string time { get; set; } //example: 010910 // Hora en formato HHMMSS
        public string masked_pan { get; set; } //example: 4123 **** **** 0025 // Pan enmascarado de la tarjeta
        public string entry_mode { get; set; } //example: N@5 // modo de entrada de la tarjeta D@5=BANDA, C@5=EMV, N@5=NFC
        public string card_type { get; set; } //example: VISA // VISA, MASTERCARD
        public string lot { get; set; } //example: 014 // lote de la transaccion
        public string merchant_id { get; set; } //example: 000000167391001 // Numero de afiliado
    }
}
