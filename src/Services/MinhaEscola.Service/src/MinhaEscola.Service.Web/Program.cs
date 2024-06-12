global using FastEndpoints;
using Consul;
using FastEndpoints.Swagger;
using FluentValidation.Results;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Infrastructure.Data.Context;
using MinhaEscola.Service.Infrastructure.IOC;
using MinhaEscola.Service.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);


builder.AddAppSettingConfiguration();

builder.Services.AddFastEndpoints();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddJsonSerializerConfiguration();

builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "Minha Escola - Service";
        s.Version = "v1";
    };
}).SwaggerDocument(o =>
   {
       o.MaxEndpointVersion = 1;
       o.DocumentSettings = s =>
       {
           s.DocumentName = "Release 1.0";
           s.Title = "my api";
           s.Version = "v1.0";
       };
   })
   .SwaggerDocument(o =>
   {
       o.MaxEndpointVersion = 2;
       o.DocumentSettings = s =>
       {
           s.DocumentName = "Release 2.0";
           s.Title = "my api";
           s.Version = "v2.0";
       };
   });

builder.Services.AddIocRegistryBasicConfiguration(builder);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionEvents = builder.Configuration.GetConnectionString("MartenConnection");

builder.Services.AddCors(x => x.AddPolicy("Total", 
    y => y.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
));

builder.Services.AddApiVersioningConfiguration();
builder.Services.AddAutoMapperConfiguration();
builder.Services.RegisterServicesToRepositories();
builder.Services.AssignValidationConfiguration();
builder.Services.AddMartenConfiguration(connectionEvents);

builder.Services.AddHealthChecks().AddDbContextCheck<ApplicationContext>();

var consulAddress = builder.Configuration.GetSection("Consul")["Url"];
var identityHost = builder.Configuration.GetSection("IdentityHost");

builder.Services.AddSingleton<IConsulClient, ConsulClient>(provider =>
    new ConsulClient(config => {
        config.Address = new Uri(consulAddress);
    }));

builder.AddAuthenticationConfiguration();

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

app.AddApiVersionGroupConfigurationApp();

app.UseFastEndpoints();

app.UseSwaggerGen();

app.Run();