using Microsoft.AspNetCore.Mvc;
using Thanos.Frame.Pipelines;
using Thanos.Frame.Swagger.Extensions;
using Thanos.Frame.Versioning.Extensions;

namespace Thanos.Domains.Accounts.Create;

public class Endpoint (
    Handler _handler,
    Swagger _swagger
) : IEndpoint
{
    public void MapRoute(WebApplication app)
    {
        app
        .MapPost(Routes.ACCOUNTS, Reply)
        .AddApiVersions([1])
        .WithSwagger(_swagger)
        ;
    }

    public async Task<IResult> Reply(
        [FromBody] Request body
    ){
        var pipeline = new Pipeline<Context>();

        var context = new Context {
            Request = body
        };

        var handled = await _handler.Handle (
            pipeline,
            context
        );

        return handled.Response;
    }
}
