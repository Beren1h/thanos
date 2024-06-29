using Microsoft.AspNetCore.Mvc;
using NanoidDotNet;
using Thanos.Common.Datastore;

namespace Thanos.Domains.Metadata;

public class Endpoint(
    Datastore.Metadata.Gateway gateway
) : IEndpoint
{
    public void MapRoute(WebApplication app)
    {
        // app
        // .MapGet("metadata", Reply2);
        
        app
        .MapPost("metadata", Reply);
    }

    public IResult Reply (
        [FromBody] Request body
    ){
        
    }
    // public IResult Reply2(
    //     [FromQuery] string id
    // ){
    //     var stream = gateway.Stream(id);

    //     return Results.Ok(stream);
    // }

    // public IResult Reply(
    //     [FromBody] Request body
    // ){
    //     var transactionId = Nanoid.Generate(size: 10);

    //     var transaction = new TransactionEvent {
    //         Transaction = new Transaction {
    //             TransactionId = transactionId,
    //             AccountId = "",
    //             ForecastId = "",
    //             CategoyId = "",
    //             ActionId = "",
    //             Date = body.Date,
    //             Amount = body.Amount
    //         }
    //     };

    //     // var transaction = new TransactionCreated{
    //     //     TransactionId = transactionId,
    //     //     Date = body.Date,
    //     //     Amount = body.Amount
    //     // };

    //     gateway.Append(transaction);

    //     return Results.Ok(transactionId);
    // }
}
