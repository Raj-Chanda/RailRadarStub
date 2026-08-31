using System;
using WireMock.Server;

namespace RailRadarStub.Requests.Interfaces;

public interface IWireMockConfiguration
{
    WireMockServer SendResponse(WireMockServer server, IServiceProvider serviceProvider);
}
