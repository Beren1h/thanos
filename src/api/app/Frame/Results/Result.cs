namespace Thanos.Frame.Results;

public class Result<T>
{
    public Result () {}

    public Result (T resource)
    {
        Resource = resource;
    }

    public Result (Exception fault)
    {
        Fault = fault;
    }

    public static implicit operator Result<T>(Exception fault) => new(fault);

    public static implicit operator Result<T>(T resource) => new(resource);

    public T Resource { get; set; }
    public Exception Fault { get; set; }
}