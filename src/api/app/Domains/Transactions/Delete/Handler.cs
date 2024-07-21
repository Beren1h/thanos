using Thanos.Frame.Pipelines;

namespace Thanos.Domains.Transactions.Delete;

public class Handler (
    CreateResponse createResponse,
    DeleteTransactions deleteTransactions
){
    public async Task<Context> Handle (
        Pipeline<Context> pipeline,
        Context context
    ){
        pipeline.Add(deleteTransactions.Invoke);
        pipeline.Add(createResponse.Invoke);

        await pipeline.Run(context);

        return context;
    }
}
