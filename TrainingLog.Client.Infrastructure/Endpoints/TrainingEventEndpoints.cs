namespace TrainingLog.Client.Infrastructure.Endpoints;

public static class TrainingEventEndpoints
{
    public static string Base() => "/api/traininglog/";
}

public static class LookupEndpoints
{
    public static string GetAllEventTypes = "api/eventtype";
}