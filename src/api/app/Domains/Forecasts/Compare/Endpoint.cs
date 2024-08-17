using Microsoft.AspNetCore.Mvc;
using Thanos.Frame.Pipelines;
using Thanos.Frame.Swagger.Extensions;
using Thanos.Frame.Versioning.Extensions;

namespace Thanos.Domains.Forecasts.Compare;

public class Endpoint (
    Handler _handler,
    Swagger _swagger
) : IEndpoint
{
    public void MapRoute(WebApplication app)
    {
        app
        .MapGet(Routes.FORECASTS_COMPARE, Reply)
        .AddApiVersions([1])
        .WithSwagger(_swagger)
        ;
    }

    public async Task<IResult> Reply(
        [FromQuery] string forecastId
    ){
        var pipeline = new Pipeline<Context>();

        var context = new Context {
            Request = new Request (
                ForecastId: forecastId
            )
        };

        var handled = await _handler.Handle (
            pipeline,
            context
        );

        return handled.Response;
    }
}
