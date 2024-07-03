using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Thanos.Frame.Swagger;

public class Options(
    IApiVersionDescriptionProvider provider
) : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        foreach(var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc (
                description.GroupName,
                new OpenApiInfo {
                    Title = $"Thanos (v{description.ApiVersion.MajorVersion})",
                    Version = description.ApiVersion.ToString(),
                    Description = "Fine. I'll do it myself."
                }
            );
        }
    }
}
