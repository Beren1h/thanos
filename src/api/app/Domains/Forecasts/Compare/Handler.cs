using Thanos.Frame.Pipelines;

namespace Thanos.Domains.Forecasts.Compare;

public class Handler (
    ValidateRequest validateRequest,
    CreateResponse createResponse,
    ReadForecast readForecast,
    ReadTransactions readTransactions,
    RunComparison runComparison
){
    public async Task<Context> Handle (
        Pipeline<Context> pipeline,
        Context context
    ){
        pipeline.Add(validateRequest.Invoke);
        pipeline.Add(readForecast.Invoke);
        pipeline.Add(readTransactions.Invoke);
        pipeline.Add(runComparison.Invoke);
        pipeline.Add(createResponse.Invoke);

        await pipeline.Run(context);

        return context;
    }
}
