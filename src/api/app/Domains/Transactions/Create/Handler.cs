using Thanos.Frame.Pipelines;

namespace Thanos.Domains.Transactions.Create;

public class Handler (
    ValidateRequest validateRequest,
    CreateResponse createResponse,
    CreateTransaction createTransaction
){
    public async Task<Context> Handle (
        Pipeline<Context> pipeline,
        Context context
    ){
        pipeline.Add(validateRequest.Invoke);
        pipeline.Add(createTransaction.Invoke);
        pipeline.Add(createResponse.Invoke);

        await pipeline.Run(context);

        return context;
    }
}
