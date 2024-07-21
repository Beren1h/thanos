using Thanos.Frame.Results.Extensions;

namespace Thanos.Domains.Transactions.Get;

public class GetTransactions (
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

            var matches = _datastore.Get<Datastore.Transaction>();

            context.HandlingResult.Resource = matches.Select(t => new Response(t));
            
            return context;
        });

        if (result.IsFaulted())
        {
            context.HandlingResult.Fault = result.Fault;
        }

        return await Task.FromResult(context);
    }
}
