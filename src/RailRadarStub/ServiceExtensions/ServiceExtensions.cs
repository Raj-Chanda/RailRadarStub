using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RailRadarStub.Responses;
using RailRadarStub.Responses.Interfaces;
using RailRadarStub.Services;
using RailRadarStub.Services.Interfaces;
using RailRadarStub.Settings;

namespace RailRadarStub.ServiceExtensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<StubServiceSettings>(configuration.GetSection(StubServiceSettings.ConfigSectionKey));
        services.AddTransient<IFileTextReader, FileTextReader>();
        services.AddTransient<IStubServiceSettingsProvider, StubServiceSettingsProvider>();
        services.AddTransient<IHubResponseProvider, TrainScheduleAndTimetableResponseProvider>();
        return services;
    }
}