using Swashbuckle.AspNetCore.SwaggerGen;
using Thanos.Frame.Startup;

namespace Thanos.Frame.Swagger;

public class Startup : IAddToBuilder, IUseWithApp
{
    public void Add(WebApplicationBuilder builder)
    {
        builder.Services
            .AddEndpointsApiExplorer()
            .AddTransient<IConfigureOptions<SwaggerGenOptions>, Options>()
            .AddSwaggerGen(o => {
                o.CustomSchemaIds (
                    type => type.FullName.Replace("+", ".")
                );
            });
    }

    public void Use(WebApplication app)
    {
        app
        .UseSwagger(o => {
            o.RouteTemplate = "thanos/{documentName}/thanos.json";
        })
        .UseSwaggerUI(o => {
            o.RoutePrefix = "thanos";
            o.EnableDeepLinking();
            o.HeadContent = "<meta names=\"robots\" content=\"noindex,nofollow\" />";
            o.SupportedSubmitMethods([]);

            foreach(var description in app.DescribeApiVersions())
            {
                var url = $"/thanos/{description.GroupName}/thanos.json";
                var name = description.GroupName.ToUpperInvariant();
                o.SwaggerEndpoint(url, name);
            }
        });
    }
}
