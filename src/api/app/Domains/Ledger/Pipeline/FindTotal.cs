namespace Thanos.Domains.Ledger;

public class FindTotal (
    Datastore.Gateway _datastore,
    FrameResults.Builder _resultBuilder
){
    public async Task<Context> Invoke(Context context)
    {
        var result = _resultBuilder.Build(() => {
            
            var transactions = _datastore.Get<Datastore.Transaction>(t => t.Month == 7);

            var total = transactions.Sum(t => t.Amount);

            return context;
        });

        return await Task.FromResult(context);
    }
}
