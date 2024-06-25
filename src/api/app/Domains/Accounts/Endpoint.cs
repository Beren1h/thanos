using Microsoft.Extensions.Options;

namespace Thanos.Domains.Accounts;

public class Endpoint(
    Datastore.Gateway gateway
) : IEndpoint
{
    public void MapRoute(WebApplication app)
    {
        app
        .MapGet("account", Reply);
    }

    public IResult Reply()
    {
        gateway.Get();
        return Results.Ok("lets see");
    }
}
