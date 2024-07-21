using Thanos.Frame.Results.Extensions;

namespace Thanos.Domains.Transactions.Delete;

public class DeleteTransactions (
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

            var wasDeleted = _datastore.Delete<Datastore.Transaction>(context.Request.Id);

            if (wasDeleted)
            {
                context.HandlingResult.Resource = context.Request.Id;
            }
            
            return context;
        });

        if (result.IsFaulted())
        {
            context.HandlingResult.Fault = result.Fault;
        }

        return await Task.FromResult(context);
    }
}
