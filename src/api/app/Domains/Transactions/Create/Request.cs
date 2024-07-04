namespace Thanos.Domains.Transactions.Create;

public record Request (
    string ChronoTag,
    // int Year,
    // int Month,
    // string WeekOf,
    DateTime? Date,
    decimal Amount,
    IEnumerable<string> Tags
);
