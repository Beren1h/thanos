using Thanos.Frame.Startup;

namespace Thanos.Frame.Settings;

public class Startup : IAddToBuilder
{
    public void Add(WebApplicationBuilder builder)
    {
        builder.Services
            .Configure<Database>(builder.Configuration.GetSection(nameof(Database)));
    }
}
