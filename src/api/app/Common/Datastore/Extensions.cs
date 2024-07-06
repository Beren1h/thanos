namespace Thanos.Common.Datastore.Extensions;

public static class Extensions
{
    public static string GetCollectionName<T>(this T poco)
    {
        return poco switch
        {
            Tag => Collections.TAGS,
            Account => Collections.ACCOUNTS,
            Transaction => Collections.TRANSACTIONS,
            _ => throw new Exception("invalid collection"),
        };
    }
}
