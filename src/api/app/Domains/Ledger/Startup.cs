using FluentValidation;
using Thanos.Frame.Startup;

namespace Thanos.Domains.Ledger;

public class Startup : IAddToBuilder, IUseWithApp
{
    public void Add(WebApplicationBuilder builder)
    {
        builder.Services
            .AddSingleton<Endpoint>()
            .AddSingleton<Handler>()
            .AddSingleton<Swagger>()
            ;

        builder.Services
            .AddSingleton<CreateResponse>()
            ;
    }

    public void Use(WebApplication app)
    {
        app.Services.GetService<Endpoint>().MapRoute(app);
    }
}
