using Thanos.Frame.Pipelines;

namespace Thanos.Domains.Helpers.Chrono;

public class Handler (
    ValidateRequest validateRequest,
    CreateResponse createResponse,
    FindWeek findWeek
){
    public async Task<Context> Handle (
        Pipeline<Context> pipeline,
        Context context
    ){
        pipeline.Add(validateRequest.Invoke);
        pipeline.Add(findWeek.Invoke);
        pipeline.Add(createResponse.Invoke);

        await pipeline.Run(context);

        return context;
    }
}
