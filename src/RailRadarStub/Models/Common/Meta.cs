using System.Runtime.Serialization;

namespace RailRadarStub.Models.Common;

[DataContract]
public class Meta
{
    [DataMember(Name = "traceId")]
    public string? TraceId { get; set; }

    [DataMember(Name = "timestamp")]
    public string? Timestamp { get; set; }

    [DataMember(Name = "executionTime")]
    public int? ExecutionTime { get; set; }

    [DataMember(Name = "source")]
    public string? Source { get; set; }
}