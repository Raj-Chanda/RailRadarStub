using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RailRadarStub.Common;
using RailRadarStub.Enums;
using RailRadarStub.Responses.Interfaces;
using RailRadarStub.Services.Interfaces;
using WireMock;
using WireMock.Matchers;
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

    public async Task<(IResponseMessage Message, IMapping? Mapping)> ProvideResponseAsync(IMapping mapping, HttpContext context, IRequestMessage requestMessage, WireMockServerSettings settings)
    {

        var result = await Task.Run(() =>
        {
            var responseMessage = CommonUtility.GetDefaultResponseMessage();
            var uri = new Uri(requestMessage.Url);

            // if (uri.PathAndQuery.Equals(new RegexMatcher("^v1\\/trains\\/\\d+$")))
            if (uri.PathAndQuery.EndsWith("v1/trains/12345"))
            {
                var fileName = "TrainScheduleAndTimetable.json";
                var fileContent = _fileTextReader.GetTextAsync(fileName).Result;

                responseMessage.StatusCode = HttpStatusCode.OK;
                responseMessage.BodyData!.BodyAsJson = fileContent;
            }

            (IResponseMessage Message, IMapping? Mapping) tup = (responseMessage, null);

            return tup;
        });

        return result;
    }
}