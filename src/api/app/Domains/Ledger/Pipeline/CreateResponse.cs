namespace Thanos.Domains.Ledger;

public class CreateResponse (
    FrameResults.Builder _resultBuilder
){
    public async Task<Context> Invoke(Context context)
    {
        // pipeline check

        var result = _resultBuilder.Build(() => {
            return context;
        });

        // result check

        return await Task.FromResult(context);
    }
}
