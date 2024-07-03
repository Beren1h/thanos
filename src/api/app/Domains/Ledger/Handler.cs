using Thanos.Frame.Pipelines;

namespace Thanos.Domains.Ledger;

public class Handler (
    CreateResponse createResponse
){
    public async Task<Context> Handle (
        Pipeline<Context> pipeline,
        Context context
    ){
        pipeline.Add(createResponse.Invoke);

        await pipeline.Run(context);

        return context;
    }
}
