namespace TrainingLog.Shared;

public abstract class Outcome
{
}

public class CommonOutcomes
{
    public class Success<T> : Outcome
    {
        public T Data { get; set; }

        public Success(T data)
        {
            Data = data;
        }
    }

    public class NotFound : Outcome
    {
    }

    public class InvalidData : Outcome
    {
        public string ParameterName { get; init; }

        public InvalidData(string parameterName)
        {
            ParameterName = parameterName;
        }
    }

    public class UnauthorizedAccess : Outcome
    {
    }

    public class Forbidden : Outcome
    {
    }

}