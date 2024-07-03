using Thanos.Frame.Results;

namespace Thanos.Domains.Ledger;

public class Context {
    public Request Request { get; set; }
    public IResult Response { get; set; } = Results.StatusCode(500);
    public Result<object> HandlingResult { get; set; } = new Result<object>();
}
