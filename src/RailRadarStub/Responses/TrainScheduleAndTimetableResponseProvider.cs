using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RailRadarStub.Common;
using RailRadarStub.Constants;
using RailRadarStub.Enums;
using RailRadarStub.Models;
using RailRadarStub.Models.Common;
using RailRadarStub.Models.Train.TrainScheduleAndTimetable;
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

    public async Task<(IResponseMessage Message, IMapping? Mapping)> ProvideResponseAsync(IMapping mapping, HttpContext context, IRequestMessage requestMessage, WireMockServerSettings settings)
    {

        var result = await Task.Run(() =>
        {
            var responseMessage = CommonUtility.GetDefaultResponseMessage();
            var uri = new Uri(requestMessage.Url);

            if (Regex.IsMatch(uri.PathAndQuery, Paths.TrainScheduleAndTimetablePath))
            {
                var fileName = "TrainScheduleAndTimetable.json";
                var fileContent = _fileTextReader.GetTextAsync(fileName).Result;

                var data = JsonConvert.DeserializeObject<Response<Data>>(fileContent);

                responseMessage.StatusCode = HttpStatusCode.OK;
                responseMessage.BodyData!.BodyAsJson = data;
            }

            (IResponseMessage Message, IMapping? Mapping) tup = (responseMessage, null);

            return tup;
        });

        return result;
    }
}