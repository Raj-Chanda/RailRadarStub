using Microsoft.Extensions.Logging;
using RailRadarStub.Enums;
using RailRadarStub.Responses.Interfaces;
using RailRadarStub.Services.Interfaces;
using WireMock;
using WireMock.Settings;

namespace RailRadarStub.Responses;

public class TrainScheduleAndTimetableResponseProvider : IHubResponseProvider
{
    private readonly ILogger<TrainScheduleAndTimetableResponseProvider> _logger;
    private readonly IFileTextReader _fileTextReader;

    public TrainScheduleAndTimetableResponseProvider(
        ILogger<TrainScheduleAndTimetableResponseProvider> logger,
        IFileTextReader fileTextReader)
    {
        _logger = logger;
        _fileTextReader = fileTextReader;
    }

    public ResponseProvider Key => ResponseProvider.TrainScheduleAndTimetable;

    public async Task<(IResponseMessage responseMessage, IMapping? mapping)> ProvideResponseAsync(IMapping mapping, IRequestMessage requestMessage, WireMockServerSettings settings)
    {

        var result = await Task.Run(() =>
        {
            var uri = new Uri(requestMessage.Url);
            
        });


    }
}