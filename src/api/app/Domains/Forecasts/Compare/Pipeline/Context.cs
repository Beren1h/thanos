using Thanos.Frame.Results;

namespace Thanos.Domains.Forecasts.Compare;

public class Context
{
    public Request Request { get; set; }
    public IResult Response { get; set; } = Results.StatusCode(500);
    public Result<object> HandlingResult { get; set; } = new Result<object>();
    public IEnumerable<Datastore.Transaction> Transactions { get; set; } = [];
    public IEnumerable<Datastore.Transaction> Forecast { get; set; } = [];
}
