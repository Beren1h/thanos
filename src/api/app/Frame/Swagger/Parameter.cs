using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Thanos.Frame.Swagger;

public record Parameter (
    string Name,
    bool Required,
    string Description
){
    public IOpenApiAny Example { get; set; }
    public Dictionary<string, OpenApiExample> Examples { get; set; }
};
