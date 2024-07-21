using Thanos.Frame.Results;

namespace Thanos.Domains.Transactions.Get;

public class Context
{
    public IResult Response { get; set; } = Results.StatusCode(500);
    public Result<IEnumerable<Response>> HandlingResult { get; set; } = new Result<IEnumerable<Response>>();
}
