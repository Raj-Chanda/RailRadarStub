using RailRadarStub.Enums;
using RailRadarStub.Requests.Interfaces;
using RailRadarStub.Responses.Interfaces;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.Server;

namespace RailRadarStub.Requests;

public class TrainScheduleAndTimetableRequestProvider : IWireMockConfiguration
{
    private readonly IDictionary<ResponseProvider, IHubResponseProvider> _responseProviders;

    public TrainScheduleAndTimetableRequestProvider(IEnumerable<IHubResponseProvider> responseProviders)
    {
        _responseProviders = responseProviders?.ToDictionary(x => x.Key)!; ;
    }

    public WireMockServer SendResponse(WireMockServer server, IServiceProvider serviceProvider)
    {
        var response = _responseProviders[ResponseProvider.TrainScheduleAndTimetable];

        server.Given(
            Request.Create()
                .WithPath(new RegexMatcher(Constants.Paths.TrainScheduleAndTimetablePath, true))
                .WithHeader(Constants.Header.AuthorizationName, new RegexMatcher(Constants.Header.AuthorizationValue))
                .UsingGet())
            .RespondWith(response);


        return server;
    }
}