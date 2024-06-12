using Consul;

namespace MinhaEscola.Service.Web.Configurations;
public static class ConsulConfiguration
{
    public static void AddConsulConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddSingleton<IConsulClient, ConsulClient>(provider =>
            new ConsulClient(config =>
            {
                config.Address = new Uri(builder.Configuration.GetSection("Consul")["Url"]);
            }));
    }
}
