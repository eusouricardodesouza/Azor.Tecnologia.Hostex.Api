using Azor.Tecnologia.Hostex.Api.Clients;
using Azor.Tecnologia.Hostex.Api.Webhooks;
using Microsoft.Extensions.DependencyInjection;

namespace Azor.Tecnologia.Hostex.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAzorHostexApi(this IServiceCollection services, string hostexAccessToken)
        {
            var url = new Uri("https://api.hostex.io/v3/");

            services.AddHttpClient<HostexApiClient>("HostexService", client =>
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Add("accept", "application/json");
                client.DefaultRequestHeaders.Add("Hostex-Access-Token", hostexAccessToken);
            });

            services.AddSingleton<WebhookService>();
            services.AddScoped<HostexApiClient>();
            return services;
        }
    }
}
