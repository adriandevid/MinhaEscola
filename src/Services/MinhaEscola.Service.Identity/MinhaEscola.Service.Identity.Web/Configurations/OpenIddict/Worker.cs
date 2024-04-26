
using MinhaEscola.Service.Identity.Web.Context;
using MinhaEscola.Service.Identity.Web.Models;
using OpenIddict.Abstractions;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace MinhaEscola.Service.Identity.Web.Configurations.OpenIddict
{
    public class Worker : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public Worker(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.EnsureCreatedAsync();

            var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();

            if (await manager.FindByClientIdAsync("console") is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "console",
                    ClientSecret = "388D45FA-B36B-4988-BA59-B187D329C207",
                    DisplayName = "My client application",
                    Permissions =
                    {
                        Permissions.Endpoints.Token,
                        Permissions.GrantTypes.ClientCredentials
                    }
                });
            }

            if (await manager.FindByClientIdAsync("client-next") is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "client-next",
                    ClientSecret = "client2123",
                    DisplayName = "client3",
                    ConsentType = ConsentTypes.Explicit,
                    RedirectUris =
                    {
                        new Uri("http://localhost:3000/api/auth/callback/identity-server4")
                    },
                    PostLogoutRedirectUris =
                    {
                        new Uri("http://localhost:5026/Account/Logout")
                    },
                    Permissions =
                    {
                        //As permissões de endpoint limitam os endpoints que um aplicativo cliente pode usar.
                        Permissions.Endpoints.Authorization,
                        Permissions.Endpoints.Logout,
                        Permissions.Endpoints.Token,

                        //As permissões de tipo de concessão limitam os tipos de concessão que um aplicativo cliente pode usar.
                        
                        //É usado para obter token de acesso fora do contexto de um usuário.
                        //Permissions.GrantTypes.ClientCredentials,

                        //É usado para trocar um código de autorização por um token de acesso
                        Permissions.GrantTypes.AuthorizationCode,
                        Permissions.ResponseTypes.Code,

                        //As permissões de escopo limitam os escopos (padrão ou personalizados) que um aplicativo cliente pode usar.
                        Permissions.Scopes.Email,
                        Permissions.Scopes.Profile,
                        Permissions.Scopes.Roles
                    },
                    Requirements =
                    {
                        Requirements.Features.ProofKeyForCodeExchange
                    }
                });
            }

            if (await manager.FindByClientIdAsync("api-service") is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "api-service",
                    ClientSecret = "api-service",
                    DisplayName = "api-service",
                    Permissions =
                    {
                        //As permissões de endpoint limitam os endpoints que um aplicativo cliente pode usar.
                        Permissions.Endpoints.Introspection
                    }
                });
            }
            
            var managerScope = scope.ServiceProvider.GetRequiredService<IOpenIddictScopeManager>();

            var scopeResult = await managerScope.FindByNameAsync("api-service");

            if (scopeResult is null)
            {
                await managerScope.CreateAsync(new ()
                {
                    Name = "api-service",
                    Resources = {
                        "api-service"
                    }
                });
            }

            bool hasProfilePattern = context.Roles.Any(role => role.Name == "Client");

            if(!hasProfilePattern) {
                context.Roles.Add(new Role() {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Client",
                    NormalizedName = "CLIENT"
                });
                
                await context.SaveChangesAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
