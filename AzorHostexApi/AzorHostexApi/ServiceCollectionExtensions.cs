using AzorHostexApi.Clients;
using AzorHostexApi.Webhooks;
using Microsoft.Extensions.DependencyInjection;

namespace AzorHostexApi
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAzorHostexApi(this IServiceCollection services, string baseUrl, string hostexAccessToken)
        {
            services.AddHttpClient<HostexApiClient>("HostexService", client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("accept", "application/json");
                client.DefaultRequestHeaders.Add("Hostex-Access-Token", hostexAccessToken);
            });

            services.AddSingleton<WebhookService>();
            services.AddScoped<HttpHostexApiClient>();
            services.AddScoped<HostexApiClient>();
            return services;
        }
    }
}
