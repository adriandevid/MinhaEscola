using OpenIddict.Validation.AspNetCore;

namespace MinhaEscola.Service.Web.Configurations;
public static class AuthenticationConfiguration
{
    public static void AddAuthenticationConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenIddict()
            .AddValidation(options =>
            {
                options.SetIssuer(builder.Configuration.GetSection("IdentityHost").Value);

                options.AddAudiences("api-service");

                options.UseIntrospection()
                    .SetClientId("api-service")
                    .SetClientSecret("api-service");

                options.UseSystemNetHttp();

                options.UseAspNetCore();
            });

        builder.Services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
        builder.Services.AddAuthorization();
    }
}
