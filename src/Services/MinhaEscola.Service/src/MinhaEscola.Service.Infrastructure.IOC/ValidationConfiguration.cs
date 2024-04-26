using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MinhaEscola.Service.Application.Extensions.Pipes;

namespace MinhaEscola.Service.Infrastructure.IOC
{
    public static class ValidationConfiguration
    {
        public static void AssignValidationConfiguration(this IServiceCollection services) {
            const string applicationAssemblyName = "MinhaEscola.Service.Application";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggerRequestBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));
           
            services.AddMediatR((config) => { 
                config.RegisterServicesFromAssembly(assembly);
            });
        }
    }
}
