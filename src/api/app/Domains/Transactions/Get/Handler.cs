using Thanos.Frame.Pipelines;

namespace Thanos.Domains.Transactions.Get;

public class Handler (
    CreateResponse createResponse,
    GetTransactions getTransactions
){
    public async Task<Context> Handle (
        Pipeline<Context> pipeline,
        Context context
    ){
        pipeline.Add(getTransactions.Invoke);
        pipeline.Add(createResponse.Invoke);

        await pipeline.Run(context);

        return context;
    }
}
