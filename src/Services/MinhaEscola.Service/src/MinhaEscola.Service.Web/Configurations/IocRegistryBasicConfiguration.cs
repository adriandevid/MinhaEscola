using System.Net.WebSockets;
using MinhaEscola.Service.Infrastructure.CrossCutting.Services.Websocket;
using MinhaEscola.Service.Infrastructure.CrossCutting.Services.Websocket.Interfaces;
using MinhaEscola.Service.Web.Models;

namespace MinhaEscola.Service.Web.Configurations;

public static class IocRegistryBasicConfiguration
{
    public static void AddIocRegistryBasicConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddSingleton<ClientWebSocket>();

        services.AddSingleton<IHostedService, ServiceDiscoveryConfiguration>();

        services.AddScoped<IWebSocketService, WebSocketService>();

        services.Configure<ApiConfigurationModel>(builder.Configuration.GetSection("ProjetoService"));
        services.Configure<ConsulConfigurationModel>(builder.Configuration.GetSection("Consul"));
    }
}
