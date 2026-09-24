using System.Runtime.Serialization;

namespace RailRadarStub.Models.Train.TrainScheduleAndTimetable;

[DataContract]
public class Route
{
    [DataMember(Name = "sequence")]
    public int? Sequence { get; set; }

    [DataMember(Name = "station")]
    public Station? station { get; set; }

    [DataMember(Name = "arrival")]
    public string? Arrival { get; set; }

    [DataMember(Name = "departure")]
    public string? Departure { get; set; }

    [DataMember(Name = "arrivalDay")]
    public int? ArrivalDay { get; set; }

    [DataMember(Name = "departureDay")]
    public int? DepartureDay { get; set; }

    [DataMember(Name = "distance")]
    public int? Distance { get; set; }

    [DataMember(Name = "isHalt")]
    public bool? IsHalt { get; set; }

    [DataMember(Name = "platform")]
    public string? Platform { get; set; }

    [DataMember(Name = "speedToNextStationKmph")]
    public int? SpeedToNextStationKmph { get; set; }
}