namespace Thanos.Domains.Transactions.Create;

public record Request (
    string ChronoId,
    string Stamp,
    decimal Amount,
    IEnumerable<string> Tags
);
