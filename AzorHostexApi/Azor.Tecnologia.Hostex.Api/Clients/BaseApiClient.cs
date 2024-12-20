using System.Net.Http.Json;

namespace Azor.Tecnologia.Hostex.Api.Clients
{
    public class BaseApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public BaseApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("HostexService");
        }

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }

            throw new HttpRequestException($"Erro ao acessar {endpoint}: {response.ReasonPhrase}");
        }

        public async Task<T?> PostAsync<T>(string endpoint, object data)
        {
            var response = await _httpClient.PostAsJsonAsync(endpoint, data);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }

            throw new HttpRequestException($"Erro ao acessar {endpoint}: {response.ReasonPhrase}");
        }

        public dynamic Error(Exception exception)
        {
            return new { error = exception.Message };
        }
    }
}
