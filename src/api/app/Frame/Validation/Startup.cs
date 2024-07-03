using Thanos.Frame.Startup;
using static System.Net.Mime.MediaTypeNames;

namespace Thanos.Frame.Validation;

public class Startup : IUseWithApp
{
    public void Use(WebApplication app)
    {
        var response = new Response (
            Errors: [
                new (
                    Code: "dotnet-model-binding",
                    Message: ".NET wasn't able complete the model binding. Check your request for large contract and/or data type mismatches",
                    Metadata: new Dictionary<string, object>()                    
                )
            ]
        );

        app.UseStatusCodePages(async context => {
            if (context.HttpContext.Response.StatusCode == 400)
            {
                context.HttpContext.Response.ContentType = Application.Json;
                await context.HttpContext.Response.WriteAsJsonAsync(response);
            }
        });        
    }
}
