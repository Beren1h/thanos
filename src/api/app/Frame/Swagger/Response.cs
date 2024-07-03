namespace Thanos.Frame.Swagger;

public record Response (
    string StatusCode,
    string Description,
    IEnumerable<Example> Examples
);
