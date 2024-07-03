namespace Thanos.Frame.Results.Extensions;

public static class Extensions
{
    public static bool IsFaulted<T> (this Result<T> result)
    {
        return result.Fault != null;
    }
}
