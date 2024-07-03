using Asp.Versioning;

namespace Thanos.Frame.Versioning.Extensions;

public static class Extensions
{
    public static ApiVersion AsApiVersion(this int version)
    {
        return version switch{
            1 => Startup.v1,
            _ => throw new Exception("unknown api version")
        };
    }

    public static RouteHandlerBuilder AddApiVersions(this RouteHandlerBuilder builder, IEnumerable<int> versions)
    {
        builder
            .WithApiVersionSet(Startup.VersionSet);
        
        foreach(var version in versions)
        {
            builder.MapToApiVersion(version.AsApiVersion());
        }

        return builder;
    }
}
