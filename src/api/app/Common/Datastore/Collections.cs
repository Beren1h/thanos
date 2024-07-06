namespace Thanos.Common.Datastore;

public struct Collection
{
    public readonly string TAGS => "tags";
    public readonly string SWITCHES => "switches";
    public readonly string TRANSACTIONS => "transactions";
}

public static class Collections
{
    public static string TAGS => "tags";
    public static string ACCOUNTS => "accounts";
    public static string TRANSACTIONS => "transactions";
}
