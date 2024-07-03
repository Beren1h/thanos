using FluentValidation;
using Thanos.Frame.Startup;

namespace Thanos.Domains.Transactions.Create;

public class Startup : IAddToBuilder, IUseWithApp
{
    public void Add(WebApplicationBuilder builder)
    {
        builder.Services
            .AddSingleton<IValidator<Validator.Model>, Validator>()
            .AddSingleton<Endpoint>()
            .AddSingleton<Handler>()
            .AddSingleton<Swagger>()
            ;

        builder.Services
            .AddSingleton<ValidateRequest>()
            .AddSingleton<CreateResponse>()
            .AddSingleton<CreateTransaction>()
            ;
    }

    public void Use(WebApplication app)
    {
        app.Services.GetService<Endpoint>().MapRoute(app);
    }
}
