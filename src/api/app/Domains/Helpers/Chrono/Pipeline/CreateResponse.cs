using Thanos.Frame.Results.Extensions;
using Thanos.Frame.Validation.Extensions;

namespace Thanos.Domains.Helpers.Chrono;

public class CreateResponse (
    FrameResults.Builder _resultBuilder
){
    public async Task<Context> Invoke(Context context)
    {
        var result = _resultBuilder.Build(() => {
            
            if (context.HandlingResult.IsFaulted())
            {
                if (context.HandlingResult.Fault is Faults.Validation invalid)
                {
                    context.Response = Results.BadRequest(invalid.Errors.AsCustomResponse());
                    return context;
                }
            }
            else
            {
                context.Response = Results.Ok(context.HandlingResult.Resource);
            }

            return context;
        });

        return await Task.FromResult(context);
    }
}
