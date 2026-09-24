using System.Runtime.Serialization;

namespace RailRadarStub.Settings;

public class StubServiceSettings
{
    public const string ConfigSectionKey = "StubServiceSettings";
    public string? ResponseDirectory { get; set; }
    public bool CacheAfterLoading { get; set; }
}