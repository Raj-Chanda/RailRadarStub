using System;
using RailRadarStub.Enums;
using WireMock.ResponseProviders;

namespace RailRadarStub.Responses.Interfaces;

public interface IHubResponseProvider : IResponseProvider
{
    ResponseProvider Key { get; }
}
