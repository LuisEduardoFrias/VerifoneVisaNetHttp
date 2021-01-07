
namespace VisaNetHttp.ShutDownHosts
{
    public class HostShutdownResponse:Exceptions
    {
        public string total_count_voids { get; set; } //example: 000000000000
        public string total_amount_voids { get; set; } //example: 0001
        public string total_amount_itbis { get; set; } //example: ECRT NEW5210 V1.01.0
        public string time { get; set; } //example: 00006575
        public string terminal_id { get; set; } //example: 000000167391001
        public string host { get; set; } //example: VISA
        public string total_amount_sales { get; set; } //example: 000000001525
        public string response_code { get; set; } //example: 301120
        public string lot { get; set; } //example: 0000
        public string merchant_id { get; set; } //example: 024
        public string date { get; set; } //example: 032949
        public string total_count_sales { get; set; } //example: 000000010000
    }
}
