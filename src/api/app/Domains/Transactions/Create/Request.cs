namespace Thanos.Domains.Transactions.Create;

public record Request (
    DateOnly? Date,
    decimal Amount,
    IEnumerable<string> Tags
);
