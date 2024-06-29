using Thanos.Frame.Startup;

namespace Thanos.Common.Datastore.Metadata;

public class Startup : IAddToBuilder
{
    public void Add(WebApplicationBuilder builder)
    {
        builder.Services
            .AddSingleton<Gateway>();
    }
}
