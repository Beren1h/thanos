namespace Thanos.Frame.Results;

public class Builder
{
    public async Task<Result<T>> Build<T> (
        Func<Task<T>> operation
    ){
        var result = new Result<T>();

        try
        {
            result.Resource = await operation();
        }
        catch (Exception ex)
        {
            result.Fault = ex;
        }

        return result;
    }

    public Result<T> Build<T> (
        Func<T> operation
    ){
        var result = new Result<T>();

        try
        {
            result.Resource = operation();
        }
        catch (Exception ex)
        {
            result.Fault = ex;
        }

        return result;
    }
}
