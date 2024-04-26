using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MinhaEscola.Service.Application.Extensions.Mappers;

namespace MinhaEscola.Service.Infrastructure.IOC
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperExtension());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
