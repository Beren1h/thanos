using Microsoft.OpenApi.Models;

namespace Thanos.Frame.Swagger;

public interface ISwaggerDefinition
{
    IEnumerable<RequestBody> RequestBodies();
    IEnumerable<Response> Responses();
    IEnumerable<Parameter> Parameters();
    Func<OpenApiOperation, OpenApiOperation> BuildOperation();
    void Add(RouteHandlerBuilder builder);
}
