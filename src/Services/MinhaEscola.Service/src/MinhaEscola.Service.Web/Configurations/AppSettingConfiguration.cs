namespace MinhaEscola.Service.Web.Configurations;
public static class AppSettingConfiguration
{
    public static void AddAppSettingConfiguration(this WebApplicationBuilder builder)
    {
        builder.Configuration
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true);
    }
}
