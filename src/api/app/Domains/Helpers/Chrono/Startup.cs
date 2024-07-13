using FluentValidation;
using Thanos.Frame.Startup;

namespace Thanos.Domains.Helpers.Chrono;

public class Startup : IAddToBuilder, IUseWithApp
{
    public void Add(WebApplicationBuilder builder)
    {
        builder.Services
            .AddSingleton<Endpoint>()
            .AddSingleton<IValidator<Validator.Model>, Validator>()
            .AddSingleton<Handler>()
            .AddSingleton<Swagger>()
            ;

        builder.Services
            .AddSingleton<CreateResponse>()
            .AddSingleton<ValidateRequest>()
            .AddSingleton<FindWeek>()
            ;
    }

    public void Use(WebApplication app)
    {
        app.Services.GetService<Endpoint>().MapRoute(app);
    }
}
