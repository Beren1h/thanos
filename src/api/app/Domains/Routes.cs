namespace Thanos.Domains;

public static class Routes
{
    private const string VERSION = "v{version:apiVersion}";

    public const string TAGS = $"{VERSION}/tags";
    public const string ACCOUNTS = $"{VERSION}/accounts";
    public const string TRANSACTIONS = $"{VERSION}/transactions";
    public const string LEDGER = $"{VERSION}/ledger";
}
