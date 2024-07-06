namespace Thanos.Domains.Ledger;

public record Request (
    string ChronoId,
    IEnumerable<string> Tags
);
