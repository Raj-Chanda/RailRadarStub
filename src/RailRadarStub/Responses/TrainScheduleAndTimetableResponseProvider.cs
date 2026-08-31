using Microsoft.Extensions.Logging;
using RailRadarStub.Responses.Interfaces;
using WireMock;

namespace RailRadarStub.Responses;

public class TrainScheduleAndTimetableResponseProvider : IHubResponseProvider
{
    private readonly ILogger<TrainScheduleAndTimetableResponseProvider> _logger;
    public ResponseMessage Respond(RequestMessage requestMessage)
    {
        var response = new ResponseMessage
        {
            StatusCode = 200,
            Body = Constants.Responses.TrainScheduleAndTimetableResponse
        };

        return response;
    }
}