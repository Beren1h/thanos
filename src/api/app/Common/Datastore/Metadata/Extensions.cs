namespace Thanos.Common.Datastore.Metadata.Extensions;

public static class Extensions
{
    public static string GetCollectionName<T>(this T poco)
    {
        return poco switch
        {
            Account => "accounts",
            Category => "categories",
            Forecast => "forecasts",
            Action => "actions",
            _ => throw new Exception(),
        };
    }
}
