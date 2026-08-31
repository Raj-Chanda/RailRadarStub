using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RailRadarStub.Common;
using RailRadarStub.Requests.Interfaces;
using RailRadarStub.Responses.Interfaces;
using Serilog;
using WireMock.Server;
using WireMock.Settings;

namespace RailRadarStub
{
    public class Program
    {
        private static IConfigurationRoot? _configuration;
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            try
            {
                ConfigureServices(services);

                var serviceProvider = services.BuildServiceProvider();

                Configure(services);

                var resaponseProvider = serviceProvider.GetRequiredService<IEnumerable<IHubResponseProvider>>();

                var serverConfig = new List<IWireMockConfiguration>
                {

                };

                StartStubServer(serverConfig, serviceProvider);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred during application startup.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            
        }

        private static void Configure(IServiceCollection services)
        {

        }

        private static void StartStubServer(List<IWireMockConfiguration> serverConfig, IServiceProvider serviceProvider)
        {
            Log.Information("===== Starting WireMock server =====");

            var server = WireMockServer.Start(new WireMockServerSettings
            {
                Urls = _configuration!.GetSection("Urls").Get<string[]>(),
                StartAdminInterface = true,
                MaxRequestLogCount = 1000,
                RequestLogExpirationDuration = 148,
                Logger = new WireMockSerilogLogger()
            });

            foreach (var config in serverConfig)
            {
                server = config.SendResponse(server, serviceProvider);
            }

            Log.Information("WireMock server started at {Url}", server.Urls[0]);

            AppDomain.CurrentDomain.ProcessExit += (s, e) =>
            {
                Log.Information("===== Stopping WireMock server =====");
                server.Stop();
                Log.Information("WireMock server stopped.");
            };

            var autoResetEvent = new AutoResetEvent(false);

            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                Log.Information("WireMock server stopped.");
                autoResetEvent.Set();
            };

            autoResetEvent.WaitOne();
            server.Stop();
        }
    }
}