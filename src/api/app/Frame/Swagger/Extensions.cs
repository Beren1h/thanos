using System.Text.Json;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Thanos.Frame.Validation;

namespace Thanos.Frame.Swagger.Extensions;

public static class Extensions
{
    public static void WithSwagger (
        this RouteHandlerBuilder builder,
        ISwaggerDefinition swagger
    ){
        swagger.Add(builder);
    }

    public static void AddTags (
        this OpenApiOperation operation,
        IEnumerable<string> tags
    ){
        var list = new List<OpenApiTag>();

        list.AddRange(tags.Select(tag => new OpenApiTag { Name = tag }));

        operation.Tags = list;
    }

    public static void AddRequestBodies (
        this OpenApiOperation operation,
        IEnumerable<RequestBody> requestBodies
    ){
        foreach(var requestBody in requestBodies)
        {
            operation.RequestBody.Content = requestBody.Examples.BuildExamples();
        }
    }

    public static void AddParameters (
        this OpenApiOperation operation,
        IEnumerable<Parameter> parameters
    ){
        foreach(var parameter in parameters)
        {
            var target = operation.Parameters.FirstOrDefault(p => p.Name == parameter.Name);

            target.Description = parameter.Description;
            target.Example = parameter.Example;
            target.Required = parameter.Required;
        }
    }

    public static void AddResponses (
        this OpenApiOperation operation,
        IEnumerable<Response> responses
    ){
        foreach(var response in responses)
        {
            var target = operation.Responses[response.StatusCode];

            target.Description = response.Description;
            target.Content = response.Examples.BuildExamples();
        }
    }

    private static Dictionary<string, OpenApiMediaType> BuildExamples (
        this IEnumerable<Example> examples
    ){
        var content = examples
            .Select(e => e.MediaType)
            .Distinct()
            .ToDictionary (
                e => e,
                e => { return new OpenApiMediaType(); }
            );
        
        foreach(var example in examples)
        {
            var serialized = JsonSerializer.Serialize (
                example.Instance,
                new JsonSerializerOptions {
                    WriteIndented = true
                }
            );

            content[example.MediaType].Examples.Add (
                example.Description,
                new OpenApiExample {
                    Value = new OpenApiString(serialized)
                }
            );
        }

        return content;
    }
}
