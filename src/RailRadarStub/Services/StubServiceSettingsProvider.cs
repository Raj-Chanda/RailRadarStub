using Microsoft.Extensions.Options;
using RailRadarStub.Services.Interfaces;
using RailRadarStub.Settings;

namespace RailRadarStub.Services;

public class StubServiceSettingsProvider : IStubServiceSettingsProvider
{
    private readonly StubServiceSettings _stubServiceSettings;

    public StubServiceSettingsProvider(
        IOptions<StubServiceSettings> stubServiceSettings)
    {
        _stubServiceSettings = stubServiceSettings.Value;
    }

    public StubServiceSettings GetSettings()
    {
        return _stubServiceSettings;
    }
}