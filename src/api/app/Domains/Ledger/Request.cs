namespace Thanos.Domains.Ledger;

public record Request (
    string ChronoId,
    string Account,
    IEnumerable<string> Tags
);
