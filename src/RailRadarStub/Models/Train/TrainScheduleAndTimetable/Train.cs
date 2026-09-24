using System.Runtime.Serialization;

namespace RailRadarStub.Models.Train.TrainScheduleAndTimetable;

[DataContract]
public class Train
{
    [DataMember(Name = "number")]
    public string? Number { get; set; }

    [DataMember(Name = "name")]
    public string? Name { get; set; }

    [DataMember(Name = "type")]
    public string? Type { get; set; }
    
    [DataMember(Name = "category")]
    public string? Category { get; set; }

    [DataMember(Name = "source")]   
    public Source? Source { get; set; }

    [DataMember(Name = "destination")]
    public Destination? Destination { get; set; }

    [DataMember(Name = "runDays")]
    public List<string>? RunDays { get; set; }

    [DataMember(Name = "distance")]
    public int? Distance { get; set; }

    [DataMember(Name = "duration")]
    public int? Duration { get; set; }

    [DataMember(Name = "avgSpeed")]
    public double? AvgSpeed { get; set; }

    [DataMember(Name = "maxSpeed")]
    public int? MaxSpeed { get; set; }

    [DataMember(Name = "totalHalts")]
    public int? TotalHalts { get; set; }

    [DataMember(Name = "returnTrain")]
    public string? ReturnTrain { get; set; }

    [DataMember(Name = "coachPosition")]
    public string? CoachPosition { get; set; }
}