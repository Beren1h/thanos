using Thanos.Frame.Startup;

namespace Thanos.Common.Datastore;

public class Startup : IAddToBuilder
{
    public void Add(WebApplicationBuilder builder)
    {
        builder.Services
            .AddSingleton<Gateway>();
    }
}
