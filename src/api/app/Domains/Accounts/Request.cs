namespace Thanos.Domains.Accounts;

public record Request(
    DateOnly Date,
    decimal Amount
);
