using Thanos.Frame.Startup;

namespace Thanos.Frame.Results;

public class Startup : IAddToBuilder
{
    public void Add(WebApplicationBuilder builder)
    {
        builder.Services
            .AddSingleton<Builder>()
            ;
    }
}
