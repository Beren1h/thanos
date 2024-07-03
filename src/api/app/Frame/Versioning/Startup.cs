using Asp.Versioning;
using Asp.Versioning.Builder;
using Thanos.Frame.Startup;

namespace Thanos.Frame.Versioning;

public class Startup : IAddToBuilder, IUseWithApp
{
    public static ApiVersionSet VersionSet => _versionSet;
    public static ApiVersion v1 => _v1;
    
    public void Add(WebApplicationBuilder builder)
    {
        _v1 = new ApiVersion(1);

        builder.Services
            .AddApiVersioning(o => {
                o.DefaultApiVersion = _v1;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddApiExplorer(o => {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            })
            ;
    }

    public void Use(WebApplication app)
    {
        _versionSet = app.NewApiVersionSet()
            .HasApiVersion(_v1)
            .ReportApiVersions()
            .Build()
            ;
    }

    private static ApiVersion _v1;
    private static ApiVersionSet _versionSet;
}
