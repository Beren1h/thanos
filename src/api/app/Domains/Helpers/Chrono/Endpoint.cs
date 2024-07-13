using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Thanos.Frame.Pipelines;
using Thanos.Frame.Swagger.Extensions;
using Thanos.Frame.Versioning.Extensions;

namespace Thanos.Domains.Helpers.Chrono;

public class Endpoint (
    Handler _handler,
    Swagger _swagger
) : IEndpoint
{
    public void MapRoute(WebApplication app)
    {
        app
        .MapGet(Routes.HELPERS_CHRONO, Reply)
        .AddApiVersions([1])
        .WithSwagger(_swagger)
        ;
    }

    public async Task<IResult> Reply(
        [FromQuery] int year,
        [FromQuery] int month
    ){
        var pipeline = new Pipeline<Context>();

        var context = new Context {
            Request = new Request (
                Year: year,
                Month: month
            )
        };

        var handled = await _handler.Handle (
            pipeline,
            context
        );

        return handled.Response;
    }
}
