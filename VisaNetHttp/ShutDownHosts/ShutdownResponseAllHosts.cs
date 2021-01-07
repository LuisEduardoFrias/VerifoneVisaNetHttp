
namespace VisaNetHttp.ShutDownHosts
{
    public class ShutdownResponseAllHosts:Exceptions
    {
        [System.Text.Json.Serialization.JsonPropertyName("visa")]
        public Visa Visa { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("mastercard")]
        public Mastercard Mastercard { get; set; } 
    }
}
