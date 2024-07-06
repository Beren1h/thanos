using System.Net.Mime;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.OpenApi.Models;
using Thanos.Frame.Swagger;
using Thanos.Frame.Swagger.Extensions;

namespace Thanos.Domains.Accounts.Create;

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
            operation.Summary = "create a new transaction tag";
            operation.Description = @"
- account
- category
- switch
- forecast
            ";
            operation.AddTags([Frame.Swagger.Tags.TAGS]);
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
        return [
            new (
                StatusCode: "200",
                Description: "success",
                Examples: []
            ),
            new (
                StatusCode: "400",
                Description: "inavlid input",
                Examples: []
            )            
        ];
    }

    public IEnumerable<RequestBody> RequestBodies()
    {
        return [
            new (
                Examples: [
                    new (
                        Description: "account tag",
                        MediaType: MediaTypeNames.Application.Json,
                        Instance: new Request (
                            Value: "1234 Bank",
                            Description: "primary checking account"
                        )
                    ),
                    new (
                        Description: "category tag",
                        MediaType: MediaTypeNames.Application.Json,
                        Instance: new Request (
                            Value: "Power",
                            Description: "category"
                        )
                    ),
                    new (
                        Description: "switch tag",
                        MediaType: MediaTypeNames.Application.Json,
                        Instance: new Request (
                            Value: "IsForeCast",
                            Description: "switch"
                        )
                    ),
                    new (
                        Description: "forecast tag",
                        MediaType: MediaTypeNames.Application.Json,
                        Instance: new Request (
                            Value: "July 2024",
                            Description: "forecast"
                        )
                    )
                ]
            )
        ];
    }
}
