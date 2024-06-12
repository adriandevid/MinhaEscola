using FastEndpoints.Swagger;

namespace MinhaEscola.Service.Web.Configurations;
public static class SwaggerConfiguration
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen();

        services.SwaggerDocument(o =>
        {
            o.DocumentSettings = s =>
            {
                s.Title = "Minha Escola - Service";
                s.Version = "v1";
            };
        });
    }
}
