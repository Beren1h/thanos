using Thanos.Frame.Pipelines;

namespace Thanos.Domains.Ledger;

public class Handler (
    ValidateRequest validateRequest,
    CreateResponse createResponse,
    RunQuery runQuery
){
    public async Task<Context> Handle (
        Pipeline<Context> pipeline,
        Context context
    ){
        pipeline.Add(validateRequest.Invoke);
        pipeline.Add(runQuery.Invoke);
        pipeline.Add(createResponse.Invoke);

        await pipeline.Run(context);

        return context;
    }
}
