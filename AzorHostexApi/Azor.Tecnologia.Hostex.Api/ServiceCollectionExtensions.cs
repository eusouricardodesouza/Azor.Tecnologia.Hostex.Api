using Azor.Tecnologia.Hostex.Api.Clients;
using Azor.Tecnologia.Hostex.Api.Webhooks;
using Microsoft.Extensions.DependencyInjection;

namespace Azor.Tecnologia.Hostex.Api
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
            services.AddScoped<HostexApiClient>();
            return services;
        }
    }
}
