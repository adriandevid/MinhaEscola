using Microsoft.AspNetCore.Http.Json;

namespace MinhaEscola.Service.Web.Configurations;
public static class JsonSerializerConfiguration
{
    public static void AddJsonSerializerConfiguration(this IServiceCollection services)
    {
        services.Configure<JsonOptions>(options =>
            options.SerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault | System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        );
    }
}
