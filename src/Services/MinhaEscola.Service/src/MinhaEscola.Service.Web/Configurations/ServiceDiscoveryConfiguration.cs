using Consul;
using Microsoft.Extensions.Options;
using MinhaEscola.Service.Web.Models;
using System.Net;

namespace MinhaEscola.Service.Web.Configurations
{
    public class ServiceDiscoveryConfiguration : IHostedService
    {
        private IConsulClient _consulClient;
        private ConsulConfigurationModel _consulConfiguration;
        private ApiConfigurationModel _projetoConfiguration;
        private ILogger<ServiceDiscoveryConfiguration> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServiceDiscoveryConfiguration(
            IConsulClient consulClient, 
            IOptions<ApiConfigurationModel> optionsGateway,
            IOptions<ConsulConfigurationModel> optionsConsul,
            ILogger<ServiceDiscoveryConfiguration> logger,
            IWebHostEnvironment webHostEnvironment)
        {
            _consulClient = consulClient;
            _consulConfiguration = optionsConsul.Value;
            _projetoConfiguration = optionsGateway.Value;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (_webHostEnvironment.IsProduction()) 
            {
                var menuUri = new Uri(_projetoConfiguration.Url);

                var headerProperties = new Dictionary<string, List<string>>();

                headerProperties.Add("Content-Type", new List<string> { "application/json" });

                var serviceRegistration = new AgentServiceRegistration()
                {
                    ID = _projetoConfiguration.ServiceId,
                    Address = menuUri.Host,
                    Name = _projetoConfiguration.ServiceName,
                    Port = menuUri.Port,
                    Tags = new[] { _projetoConfiguration.ServiceName },
                    Check = new AgentServiceCheck()
                    {
                        HTTP = $"{_projetoConfiguration.Url}/healthz",
                        TLSSkipVerify = true,
                        Method = "GET",
                        Interval = TimeSpan.FromSeconds(5),
                        DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(10)
                    }
                };

                await _consulClient.Agent.ServiceDeregister(_projetoConfiguration.ServiceId, cancellationToken);

                await _consulClient.Agent.ServiceRegister(serviceRegistration, cancellationToken);

                await _consulClient.Agent.CheckRegister(new AgentCheckRegistration
                {
                    Name = _projetoConfiguration.ServiceName,
                    HTTP = $"{_projetoConfiguration.Url}/healthz",
                    TLSSkipVerify = true,
                    Method = "GET",
                    Header = headerProperties,
                    Interval = TimeSpan.FromSeconds(5)
                });

                await _consulClient.Agent.Checks(cancellationToken);
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _consulClient.Agent.ServiceDeregister(_projetoConfiguration.ServiceId, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when trying to de-register", ex);
            }
        }

        private static string GetLocalIpAddress() 
        { 
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList) 
            { 
                if(ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("Local Ip not found");
        }
    }
}
