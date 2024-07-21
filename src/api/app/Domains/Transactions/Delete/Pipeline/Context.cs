using Thanos.Frame.Results;

namespace Thanos.Domains.Transactions.Delete;

public class Context
{
    public Request Request { get; set; }
    public IResult Response { get; set; } = Results.StatusCode(500);
    public Result<string> HandlingResult { get; set; } = new Result<string>();
}
