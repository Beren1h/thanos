using Thanos.Common.Datastore;
using Thanos.Frame.Results.Extensions;

namespace Thanos.Domains.Accounts.Create;

public class CreateAccount (
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

            var account = new Account {
                Value = context.Request.Value,
                Description = context.Request.Description
            };

            _datastore.Append(account);

            context.HandlingResult.Resource = account;
            
            return context;
        });

        if (result.IsFaulted())
        {
            context.HandlingResult.Fault = result.Fault;
        }

        return await Task.FromResult(context);
    }
}
