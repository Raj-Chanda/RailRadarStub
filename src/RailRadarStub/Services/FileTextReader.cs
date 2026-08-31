using System.Collections.Concurrent;
using System.Reflection;
using Microsoft.Extensions.Logging;
using RailRadarStub.Services.Interfaces;
using RailRadarStub.Settings;

namespace RailRadarStub.Services;

public class FileTextReader : IFileTextReader
{
    private readonly ConcurrentDictionary<string, string> _responseCache = new ConcurrentDictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
    private readonly IStubServiceSettingsProvider _stubServiceSettingsProvider;
    private readonly ILogger<FileTextReader> _logger;

    private readonly string _rootPatrh;

    public FileTextReader(
        IStubServiceSettingsProvider stubServiceSettingsProvider,
        ILogger<FileTextReader> logger)
    {
        _stubServiceSettingsProvider = stubServiceSettingsProvider;
        _logger = logger;
        _rootPatrh = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? string.Empty;
    }

    public async Task<string> GetTextAsync(string fileName)
    {

        if (string.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentException($"{nameof(fileName)} cannot be null or empty.");
        }

        var stubServiceSettings = GetStubServiceSettings();

        string responseDirectorypath = GetDirectoryPath(stubServiceSettings);

        if (!Directory.Exists(responseDirectorypath))
        {
            _logger.LogError($"Invalid directory path: {responseDirectorypath}");
            return "Invalid directory path";
        }

        string fullFileName = GetFullFileName(responseDirectorypath, fileName);
        if (!File.Exists(fullFileName))
        {
            _logger.LogError($"Response file not found: {fullFileName}");
            return "Response file not found";
        }

        if (!stubServiceSettings.CacheAfterLoading)
        {
            return await ReadFiletextAsync(fullFileName);
        }

        if (!_responseCache.ContainsKey(fileName))
        {
            _responseCache.TryAdd(fileName, await ReadFiletextAsync(fullFileName));
        }

        return _responseCache[fileName];
    }

    public async Task<bool> DoesFileExistAsync(string fileName)
    {
        var stubServiceSettings = GetStubServiceSettings();

        string responseDirectorypath = GetDirectoryPath(stubServiceSettings);

        if (!Directory.Exists(responseDirectorypath))
        {
            _logger.LogError($"Invalid directory path: {responseDirectorypath}");
            return false;
        }

        string fullFileName = GetFullFileName(responseDirectorypath, fileName);
        if (!File.Exists(fullFileName))
        {
            _logger.LogError($"Response file not found: {fullFileName}");
            return false;
        }

        return true;
    }

    private string GetFullFileName(string directoryPath, string fileName)
    {
        return Path.Combine(directoryPath, fileName);
    }

    private string GetDirectoryPath(StubServiceSettings settings)
    {
        return Path.Join(_rootPatrh, settings.ResponseDirectory);
    }

    private StubServiceSettings GetStubServiceSettings()
    {
        return _stubServiceSettingsProvider.GetSettings();
    }

    private async Task<string> ReadFiletextAsync(string fileName)
    {
        try
        {
            return await File.ReadAllTextAsync(fileName);
        }
        catch (Exception ex) when (ex is FileLoadException || ex is FileNotFoundException)
        {
            _logger.LogError(ex, $"Error reading response file: {Path.GetFileName(fileName)}");
        }

        return "Error reading response file.";
    }
}
