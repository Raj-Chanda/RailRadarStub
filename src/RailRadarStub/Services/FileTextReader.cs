using System.Reflection;
using Microsoft.Extensions.Logging;
using RailRadarStub.Services.Interfaces;

namespace RailRadarStub.Services;

public class FileTextReader : IFileTextReader
{
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
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"The file '{fileName}' does not exist.");
        }

        return await File.ReadAllTextAsync(fileName);
    }

    public async Task<bool> DoesFileExistAsync(string fileName)
    {
        return await Task.FromResult(File.Exists(fileName));
    }
}
