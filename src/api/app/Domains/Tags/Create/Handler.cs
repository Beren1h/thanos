using Thanos.Frame.Pipelines;

namespace Thanos.Domains.Tags.Create;

public class Handler (
    ValidateRequest validateRequest,
    CreateResponse createResponse,
    CreateTag createTag
){
    public async Task<Context> Handle (
        Pipeline<Context> pipeline,
        Context context
    ){
        pipeline.Add(validateRequest.Invoke);
        pipeline.Add(createTag.Invoke);
        pipeline.Add(createResponse.Invoke);

        await pipeline.Run(context);

        return context;
    }
}
