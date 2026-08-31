namespace RailRadarStub.Constants;

public static class Paths
{
    public const string TrainScheduleAndTimetablePath = @"/v1/trains/[a-zA-Z0-9]+$";
    public const string LiveTrainRunningStatusPath = @"/v1/trains/[a-zA-Z0-9]+$/live";
}