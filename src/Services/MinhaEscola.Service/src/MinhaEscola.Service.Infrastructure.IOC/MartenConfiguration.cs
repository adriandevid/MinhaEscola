using Marten;
using Microsoft.Extensions.DependencyInjection;

namespace MinhaEscola.Service.Infrastructure.IOC
{
    public static class MartenConfiguration
    {
        public static void AddMartenConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddMarten(configuration => {
                configuration.Events.StreamIdentity = Marten.Events.StreamIdentity.AsGuid;
                configuration.Connection(connectionString);
            });
        }
    }
}
