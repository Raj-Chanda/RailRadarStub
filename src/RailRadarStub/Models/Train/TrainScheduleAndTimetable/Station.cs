using System.Runtime.Serialization;

namespace RailRadarStub.Models.Train.TrainScheduleAndTimetable;

[DataContract]
public class Station
{
    [DataMember(Name = "code")]
    public string? Code { get; set; }

    [DataMember(Name = "name")]
    public string? Name { get; set; }
}