using Thanos.Frame.Pipelines;
using Thanos.Frame.Swagger.Extensions;
using Thanos.Frame.Versioning.Extensions;

namespace Thanos.Domains.Transactions.Delete;

public class Endpoint (
    Handler _handler,
    Swagger _swagger
) : IEndpoint
{
    public void MapRoute(WebApplication app)
    {
        app
        .MapDelete(Routes.TRANSACTIONS, Reply)
        .AddApiVersions([1])
        .WithSwagger(_swagger)
        ;
    }

    public async Task<IResult> Reply(
        string id
    ){
        var pipeline = new Pipeline<Context>();

        var context = new Context {
            Request = new Request (
                Id: id
            )
        };

        var handled = await _handler.Handle (
            pipeline,
            context
        );

        return handled.Response;
    }
}
