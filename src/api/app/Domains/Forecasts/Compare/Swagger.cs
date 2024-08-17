using System.Net.Mime;
using Microsoft.OpenApi.Models;
using Thanos.Frame.Swagger;
using Thanos.Frame.Swagger.Extensions;

namespace Thanos.Domains.Forecasts.Compare;

public class Swagger : ISwaggerDefinition
{
    public void Add(RouteHandlerBuilder builder)
    {
        builder
            .WithOpenApi(BuildOperation())
            .Produces(200)
            .Produces(400)
            ;
    }

    public Func<OpenApiOperation, OpenApiOperation> BuildOperation()
    {
        return (operation) => {
            operation.Summary = "";
            operation.Description = "";
            operation.AddTags([Frame.Swagger.Tags.FORECASTS]);
            operation.AddRequestBodies(RequestBodies());
            operation.AddParameters(Parameters());
            operation.AddResponses(Responses());
            return operation;
        };
    }

    public IEnumerable<Parameter> Parameters()
    {
        return [];
    }

    public IEnumerable<Response> Responses()
    {
        return [];
    }

    public IEnumerable<RequestBody> RequestBodies()
    {
        return [];
    }
}
