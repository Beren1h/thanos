using Thanos.Frame.Startup;

namespace Thanos.Domains.Metadata;

public class Startup : IUseWithApp, IAddToBuilder
{
    public void Add(WebApplicationBuilder builder)
    {
        builder.Services
            .AddSingleton<Endpoint>();
    }

    public void Use(WebApplication app)
    {
        app.Services.GetService<Endpoint>().MapRoute(app);
    }
}
