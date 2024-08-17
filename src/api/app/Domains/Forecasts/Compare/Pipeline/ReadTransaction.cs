using Thanos.Common;
using Thanos.Frame.Results.Extensions;

namespace Thanos.Domains.Forecasts.Compare;

public class ReadTransactions (
    Datastore.Gateway _datastore,
    FrameResults.Builder _resultBuilder
){
    public async Task<Context> Invoke(Context context)
    {
        if (context.HandlingResult.IsFaulted())
        {
            return context;
        }

        var result = _resultBuilder.Build(() => {
            
            var split = context.Request.ForecastId.Split('-'); 
            var year = int.Parse(split[0]);
            var month = int.Parse(split[1]);

            var transactions = _datastore.Get<Datastore.Transaction> (
                t => t.Year == year && 
                t.Month == month &&
                !t.Tags.Contains("Opening Balance")
            );
            
            context.Transactions = transactions;

            return context;
        });

        if (result.IsFaulted())
        {
            context.HandlingResult.Fault = result.Fault;
        }

        return await Task.FromResult(context);
    }
}
