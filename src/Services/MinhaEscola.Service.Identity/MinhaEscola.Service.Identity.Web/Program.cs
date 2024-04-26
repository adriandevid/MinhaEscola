using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MinhaEscola.Service.Identity.Web.Configurations.OpenIddict;
using MinhaEscola.Service.Identity.Web.Context;
using MinhaEscola.Service.Identity.Web.Models;

using static OpenIddict.Abstractions.OpenIddictConstants;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true);

builder.Services.AddCors(
        options =>
        options.AddPolicy("Total",
            policy =>
            policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
       )
);

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages((options) => {
    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "common/oauth/authorize/signin");
    options.Conventions.AddAreaPageRoute("Identity", "/Account/Register", "common/oauth/authorize/signup");
    options.Conventions.AddAreaPageRoute("Identity", "/Error", "common/oauth/error");
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseOpenIddict();
});

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

builder.Services.AddOpenIddict()
    .AddCore(options =>
    {
        options.UseEntityFrameworkCore()
               .UseDbContext<ApplicationDbContext>();
    })
    .AddServer(options =>
    {
        options.SetAccessTokenLifetime(TimeSpan.FromHours(2));
        options.SetAuthorizationEndpointUris("/connect/authorize")
                       .SetLogoutEndpointUris("/connect/logout")
                       .SetTokenEndpointUris("/connect/token")
                       .SetUserinfoEndpointUris("/connect/userinfo")
                       .SetIntrospectionEndpointUris("introspect");

        options.AllowAuthorizationCodeFlow().AllowRefreshTokenFlow();
        
        options.RegisterScopes(Scopes.Email, Scopes.Profile, Scopes.Roles);

        options.AddDevelopmentEncryptionCertificate()
               .AddDevelopmentSigningCertificate();

        //options.AddEncryptionKey(new SymmetricSecurityKey(
        //   Convert.FromBase64String("DRjd/GnduI3Efzen9V9BvbNUfc/VKgXltV7Kbk9sMkY=")));

        options.UseAspNetCore()
                       .EnableAuthorizationEndpointPassthrough()
                       .EnableLogoutEndpointPassthrough()
                       .EnableTokenEndpointPassthrough()
                       .EnableUserinfoEndpointPassthrough()
                       .EnableStatusCodePagesIntegration()
                       .DisableTransportSecurityRequirement();
    })
    .AddValidation(options =>
    {
        options.UseLocalServer();
        options.UseAspNetCore();
    });

builder.Services.AddHostedService<Worker>();


var app = builder.Build();

app.UseCors("Total");

app.UseExceptionHandler("/common/oauth/error");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(options =>
{
    options.MapControllers();
    options.MapDefaultControllerRoute();
    options.MapRazorPages();
});

app.Run();
