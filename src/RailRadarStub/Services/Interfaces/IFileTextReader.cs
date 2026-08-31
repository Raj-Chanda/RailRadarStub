namespace RailRadarStub.Services.Interfaces;

public interface IFileTextReader
{
    Task<string> GetTextAsync(string fileName);
    Task<bool> DoesFileExistAsync(string fileName);
}