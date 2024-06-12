using Asp.Versioning;
using Asp.Versioning.Builder;

namespace MinhaEscola.Service.Web.Configurations;
public static class ApiVersioning
{
    public static void AddApiVersioningConfiguration(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        })
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        }).EnableApiVersionBinding();
    }

    public static void AddApiVersionGroupConfigurationApp(this WebApplication app) {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1))
            .ReportApiVersions()
            .Build();

        app
            .MapGroup("api/v{version:apiVersion}/address")
            .WithApiVersionSet(apiVersionSet);

        // group.MapGet("workouts/{workoutId}", ...);
    }
}
