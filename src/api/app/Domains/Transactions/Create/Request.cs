namespace Thanos.Domains.Transactions.Create;

public record Request (
    string ChronoId,
    string Stamp,
    string Account,
    string Note,
    decimal Amount,
    IEnumerable<string> Tags
);
