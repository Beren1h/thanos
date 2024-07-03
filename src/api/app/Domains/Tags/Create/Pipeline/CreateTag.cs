using Thanos.Common.Datastore;
using Thanos.Frame.Results.Extensions;

namespace Thanos.Domains.Tags.Create;

public class CreateTag (
    Datastore.Gateway _datastore,
    FrameResults.Builder _resultBuilder
){
    public async Task<Context> Invoke(Context context)
    {
        if (context.HandlingResult.IsFaulted())
        {
            return context;
        }

        var result = _resultBuilder.Build(() => {

            var tag = new Tag {
                Value = context.Request.Value,
                Description = context.Request.Description
            };

            _datastore.Append(tag);

            context.HandlingResult.Resource = tag;
            
            return context;
        });

        if (result.IsFaulted())
        {
            context.HandlingResult.Fault = result.Fault;
        }

        return await Task.FromResult(context);
    }
}
