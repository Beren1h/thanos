namespace Thanos.Domains;

public static class Routes
{
    private const string VERSION = "v{version:apiVersion}";
    private const string HELPERS = $"{VERSION}/helpers";

    public const string HELPERS_CHRONO = $"{HELPERS}/chrono";
    public const string TAGS = $"{VERSION}/tags";
    public const string ACCOUNTS = $"{VERSION}/accounts";
    public const string TRANSACTIONS = $"{VERSION}/transactions";
    public const string LEDGER = $"{VERSION}/ledger";
    public const string FORECASTS = $"{VERSION}/forecasts";
    public const string FORECASTS_COMPARE = $"{FORECASTS}/compare";
}
