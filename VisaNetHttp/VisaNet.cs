
namespace VisaNetHttp
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.Json;
    using System.Net;
    //
    using VisaNetHttp.Authentications;
    using VisaNetHttp.Sales;
    using VisaNetHttp.Annulments;
    using VisaNetHttp.ShutDownHosts;
    using System.IO;
    //

    public class VisaNet
    {
        private readonly HttpClient _Cliente = null;
        private readonly App app;
        private readonly JsonSerializerOptions options;

        public VisaNet()
        {
            if (_Cliente == null)
            {
                app = new App();

                options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                };

                _Cliente = new HttpClient();
                _Cliente.BaseAddress = new Uri(app.BaseUrl);
                _Cliente.DefaultRequestHeaders.Accept.Clear();
                _Cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }


        //Obtain authorization asynchronously, returns an authorization token.
        public async Task<Token> AuthenticationAsync(UserAuthentication userAutenticacion)
        {
            try
            {
                HttpRequestMessage _Solicitud = new HttpRequestMessage(HttpMethod.Post, app.Auth);

                _Solicitud.Content = new StringContent(
                    JsonSerializer.Serialize<UserAuthentication>(userAutenticacion),
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage _Respuesta = await _Cliente.SendAsync(
                    _Solicitud,
                    HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);


                if (_Respuesta.IsSuccessStatusCode)
                    return JsonSerializer.Deserialize<Token>(await _Respuesta.Content.ReadAsStringAsync());

                else if (_Respuesta.StatusCode == HttpStatusCode.BadRequest ||
                         _Respuesta.StatusCode == HttpStatusCode.Unauthorized ||
                         _Respuesta.StatusCode == HttpStatusCode.NotFound ||
                         _Respuesta.StatusCode == HttpStatusCode.Forbidden)
                     {
                         return new Token() { Exection = _Respuesta.StatusCode.ToString() };
                     }

            }
            catch (Exception ex)
            {
                return new Token() { Exection = ex.Message.ToString() };
            }

            return null;
        }

        //Makes a sale asynchronously, returns a sale response.
        public async Task<SaleResponse> MakeSaleAsync(Sale sale, Token taken)
        {
            try
            {
                HttpRequestMessage _Solicitud = new HttpRequestMessage(HttpMethod.Post, app.OtherOperations);
                _Solicitud.Headers.Add("Authorization", "Bearer " + taken.jwt_token);

                _Solicitud.Content = new StringContent( 
                    JsonSerializer.Serialize<Sale>(sale), 
                    Encoding.UTF8, 
                    "application/json");

                HttpResponseMessage _Respuesta = await _Cliente.SendAsync(
                    _Solicitud, 
                    HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                if (_Respuesta.IsSuccessStatusCode)
                    return JsonSerializer.Deserialize<SaleResponse>(await _Respuesta.Content.ReadAsStringAsync());

                else if (_Respuesta.StatusCode == HttpStatusCode.BadRequest     ||
                         _Respuesta.StatusCode == HttpStatusCode.Unauthorized   ||
                         _Respuesta.StatusCode == HttpStatusCode.NotFound       ||
                         _Respuesta.StatusCode == HttpStatusCode.Forbidden)
                     {
                         return new SaleResponse() { Exection = _Respuesta.StatusCode.ToString() };
                     }

            }
            catch (Exception ex)
            {
                return new SaleResponse() { Exection = ex.Message.ToString() };
            }

            return null;

        }

        //Cancels a sale made asynchronously, returns a cancellation response.
        public async Task<AnnulmentResponse> MakeAnnulmentAsync(Annulment annulment, Token taken)
        {
            try
            {
                HttpRequestMessage _Solicitud = new HttpRequestMessage(HttpMethod.Post, app.OtherOperations);
                _Solicitud.Headers.Add("Authorization", "Bearer " + taken.jwt_token);

                _Solicitud.Content = new StringContent(
                    JsonSerializer.Serialize<Annulment>(annulment),
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage _Respuesta = await _Cliente.SendAsync(
                    _Solicitud,
                    HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                if (_Respuesta.IsSuccessStatusCode)
                    return JsonSerializer.Deserialize<AnnulmentResponse>(await _Respuesta.Content.ReadAsStringAsync());

                else if (_Respuesta.StatusCode == HttpStatusCode.BadRequest ||
                         _Respuesta.StatusCode == HttpStatusCode.Unauthorized ||
                         _Respuesta.StatusCode == HttpStatusCode.NotFound ||
                         _Respuesta.StatusCode == HttpStatusCode.Forbidden)
                     {
                        return new AnnulmentResponse() { Exection = _Respuesta.StatusCode.ToString() };
                     }

            }
            catch (Exception ex)
            {
                return new AnnulmentResponse() { Exection = ex.Message.ToString() };
            }

            return null;

        }

        //Closes a hot asynchronously, returns a closing response.
        public async Task<HostShutdownResponse> ShutDownSingleHostAsync(CloseHosts closeHosts, Token taken)
        {
            try
            {
                HttpRequestMessage _Solicitud = new HttpRequestMessage(HttpMethod.Post, app.OtherOperations);
                _Solicitud.Headers.Add("Authorization", "Bearer " + taken.jwt_token);

                _Solicitud.Content = new StringContent(
                    JsonSerializer.Serialize<CloseHosts>(closeHosts),
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage _Respuesta = await _Cliente.SendAsync(
                    _Solicitud,
                    HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                if (_Respuesta.IsSuccessStatusCode)
                    return await JsonSerializer.DeserializeAsync<HostShutdownResponse>(
                        new MemoryStream(
                            Encoding.UTF8.GetBytes(
                                await _Respuesta.Content.ReadAsStringAsync())), options, new System.Threading.CancellationToken());

                else if (_Respuesta.StatusCode == HttpStatusCode.BadRequest ||
                         _Respuesta.StatusCode == HttpStatusCode.Unauthorized ||
                         _Respuesta.StatusCode == HttpStatusCode.NotFound ||
                         _Respuesta.StatusCode == HttpStatusCode.Forbidden)
                     {
                        return new HostShutdownResponse() { Exection = _Respuesta.StatusCode.ToString() };
                     }

            }
            catch (Exception ex)
            {
                return new HostShutdownResponse() { Exection = ex.Message.ToString() };
            }

            return null;

        }

        //It closes all the hots asynchronously, returns a response of the closures.
        public async Task<ShutdownResponseAllHosts> ShutdownFromAllHostsAsync(CloseHosts closeHosts, Token taken)
        {
            try
            {
                HttpRequestMessage _Solicitud = new HttpRequestMessage(HttpMethod.Post, app.OtherOperations);
                _Solicitud.Headers.Add("Authorization", "Bearer " + taken.jwt_token);

                _Solicitud.Content = new StringContent(
                    JsonSerializer.Serialize<CloseHosts>(closeHosts),
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage _Respuesta = await _Cliente.SendAsync(
                    _Solicitud,
                    HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                if (_Respuesta.IsSuccessStatusCode)
                    return await JsonSerializer.DeserializeAsync<ShutdownResponseAllHosts>(
                        new MemoryStream(
                            Encoding.UTF8.GetBytes(
                                await _Respuesta.Content.ReadAsStringAsync())), options, new System.Threading.CancellationToken());

                else if (_Respuesta.StatusCode == HttpStatusCode.BadRequest ||
                         _Respuesta.StatusCode == HttpStatusCode.Unauthorized ||
                         _Respuesta.StatusCode == HttpStatusCode.NotFound ||
                         _Respuesta.StatusCode == HttpStatusCode.Forbidden)
                {
                    return new ShutdownResponseAllHosts() { Exection = _Respuesta.StatusCode.ToString() };
                }

            }
            catch (Exception ex)
            {
                return new ShutdownResponseAllHosts() { Exection = ex.Message.ToString() };
            }

            return null;

        }

    }
}
