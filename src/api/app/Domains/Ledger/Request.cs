namespace Thanos.Domains.Ledger;

public record Request (
    DateOnly? Start,
    DateOnly? End,
    IEnumerable<string> Tags
);
