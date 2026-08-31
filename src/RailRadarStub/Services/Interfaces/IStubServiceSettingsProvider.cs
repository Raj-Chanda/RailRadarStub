using RailRadarStub.Settings;

namespace RailRadarStub.Services.Interfaces;

public interface IStubServiceSettingsProvider
{
    StubServiceSettings GetSettings();
}