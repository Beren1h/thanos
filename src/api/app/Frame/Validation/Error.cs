namespace Thanos.Frame.Validation;

public record Error (
    string Code,
    string Message,
    IDictionary<string, object> Metadata
);
