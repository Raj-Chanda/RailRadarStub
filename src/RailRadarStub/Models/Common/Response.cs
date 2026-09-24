using System.Runtime.Serialization;

namespace RailRadarStub.Models.Common;

[DataContract]
public class Response<T> where T : class
{
    [DataMember(Name = "success")]
    public bool? Success { get; set; }

    [DataMember(Name = "data")]
    public T? Data { get; set; }

    [DataMember(Name = "meta")]
    public Meta? Meta { get; set; }
}