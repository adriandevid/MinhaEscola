global using FastEndpoints;
using Consul;
using FastEndpoints.Swagger;
using FluentValidation.Results;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Infrastructure.CrossCutting.Services.Websocket;
using MinhaEscola.Service.Infrastructure.CrossCutting.Services.Websocket.Interfaces;
using MinhaEscola.Service.Infrastructure.Data.Context;
using MinhaEscola.Service.Infrastructure.IOC;
using MinhaEscola.Service.Web.Configurations;
using MinhaEscola.Service.Web.Models;
using OpenIddict.Validation.AspNetCore;
using System.Net.WebSockets;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true);

builder.Services.AddFastEndpoints();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(options =>
    options.SerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault | System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);

builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "Minha Escola - Service";
        s.Version = "v1";
    };
});

builder.Services.AddSingleton<ClientWebSocket>();

builder.Services.AddSingleton<IHostedService, ServiceDiscoveryConfiguration>();

builder.Services.AddScoped<IWebSocketService, WebSocketService>();

builder.Services.Configure<ApiConfigurationModel>(builder.Configuration.GetSection("ProjetoService"));
builder.Services.Configure<ConsulConfigurationModel>(builder.Configuration.GetSection("Consul"));

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionEvents = builder.Configuration.GetConnectionString("MartenConnection");

builder.Services.AddCors(x => x.AddPolicy("Total", 
    y => y.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
));

builder.Services.AddAutoMapperConfiguration();
builder.Services.RegisterServicesToRepositories();
builder.Services.AssignValidationConfiguration();
builder.Services.AddMartenConfiguration(connectionEvents);

builder.Services.AddHealthChecks()
    .AddDbContextCheck<ApplicationContext>();

var consulAddress = builder.Configuration.GetSection("Consul")["Url"];
var identityHost = builder.Configuration.GetSection("IdentityHost");

builder.Services.AddSingleton<IConsulClient, ConsulClient>(provider =>
    new ConsulClient(config => {
        config.Address = new Uri(consulAddress);
    }));

builder.Services.AddOpenIddict()
    .AddValidation(options =>
    {
        options.SetIssuer(identityHost.Value);
        
        options.AddAudiences("api-service");
        
        options.UseIntrospection()
               .SetClientId("api-service")
               .SetClientSecret("api-service");

        options.UseSystemNetHttp();

        options.UseAspNetCore();
    });

builder.Services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
builder.Services.AddAuthorization();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(connection);
    options.EnableSensitiveDataLogging();
});

var app = builder.Build();


//ClientWebSocket clientWebSockect = (ClientWebSocket)app.Services.GetService(typeof(ClientWebSocket));

//await clientWebSockect!.ConnectAsync(new Uri("ws://localhost:8080/"), CancellationToken.None);

//await clientWebSockect!.SendAsync(Encoding.UTF8.GetBytes("ola mundo"), WebSocketMessageType.Text, true, CancellationToken.None);
//Console.WriteLine(clientWebSockect.State.ToString());

app.UseExceptionHandler(errorApp => {
    errorApp.Run(async ctx =>
    {
        var exHandlerFeature = ctx.Features.Get<IExceptionHandlerFeature>();
        await ctx.Response.WriteAsJsonAsync(new ApiResponse()
        {
            ValidationResult = new ValidationResult(
                    new List<ValidationFailure>() {
                        new ValidationFailure() {
                            ErrorMessage = exHandlerFeature.Error.Message
                        }
                    }
                )
        });
    });
});

app.UseAuthentication();
app.UseAuthorization();

app.MapHealthChecks("/healthz");

app.UseCors("Total");

app.UseFastEndpoints();

app.UseSwaggerGen();

app.Run();