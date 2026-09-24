using System.Runtime.Serialization;

namespace RailRadarStub.Models.Base;

[DataContract]
public class BaseData
{
    [DataMember(Name = "success")]
    public bool? Success { get; set; }

    [DataMember(Name = "meta")]
    public MetaData? Meta { get; set; }
}