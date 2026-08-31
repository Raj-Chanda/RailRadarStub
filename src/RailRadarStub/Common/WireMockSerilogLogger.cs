using WireMock.Admin.Requests;
using WireMock.Logging;

namespace RailRadarStub.Common;

public class WireMockSerilogLogger : IWireMockLogger
{
    private static readonly Serilog.ILogger _log = Serilog.Log.Logger;
    public void Debug(string? formatString, params object?[] args)
    {
        _log.Debug(formatString, args);
    }

    public void Info(string? formatString, params object?[] args)
    {
        _log.Information(formatString, args);
    }

    public void Warn(string? formatString, params object?[] args)
    {
        _log.Warning(formatString, args);
    }

    public void Error(string? formatString, params object?[] args)
    {
        _log.Error(formatString, args);
    }

    public void Error(string? formatString, Exception exception)
    {
        _log.Error(exception, formatString);
    }

    public void DebugRequestResponse(LogEntryModel logEntryModel, bool isAdminrequest)
    {
        _log.Debug("Request: {@Request}, Response: {@Response}, IsAdminRequest: {IsAdminRequest}");
    }
}