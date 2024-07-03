using Thanos.Common.Datastore;
using Thanos.Frame.Results.Extensions;

namespace Thanos.Domains.Transactions.Create;

public class CreateTransaction (
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

            var transaction = new Transaction {
                Date = context.Request.Date,
                Amount = context.Request.Amount,
                Tags = context.Request.Tags
            };

            _datastore.Append(transaction);

            context.HandlingResult.Resource = transaction;
            
            return context;
        });

        if (result.IsFaulted())
        {
            context.HandlingResult.Fault = result.Fault;
        }

        return await Task.FromResult(context);
    }
}
