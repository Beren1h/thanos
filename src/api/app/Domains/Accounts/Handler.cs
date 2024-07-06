using Thanos.Frame.Pipelines;

namespace Thanos.Domains.Accounts.Create;

public class Handler (
    ValidateRequest validateRequest,
    CreateResponse createResponse,
    CreateAccount createAccount
){
    public async Task<Context> Handle (
        Pipeline<Context> pipeline,
        Context context
    ){
        pipeline.Add(validateRequest.Invoke);
        pipeline.Add(createAccount.Invoke);
        pipeline.Add(createResponse.Invoke);

        await pipeline.Run(context);

        return context;
    }
}
