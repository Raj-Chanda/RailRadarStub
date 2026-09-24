using System.Runtime.Serialization;

namespace RailRadarStub.Models.Train.TrainScheduleAndTimetable;

[DataContract]
public class Data
{
    [DataMember(Name = "train")]
    public Train? Train { get; set; }

    [DataMember(Name = "route")]
    public List<Route>? Route { get; set; }
}