namespace Thanos.Domains.Tags.Create;

public class Template (
    FrameResults.Builder _resultBuilder
){
    public async Task<Context> Invoke(Context context)
    {
        // skip step checking

        var result = await _resultBuilder.Build(async () => {
            return await Task.FromResult(context);
        });

        // result faulted checking

        return context;
    }
}
