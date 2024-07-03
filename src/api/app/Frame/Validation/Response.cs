namespace Thanos.Frame.Validation;

public record Response (
    IEnumerable<Error> Errors
);
