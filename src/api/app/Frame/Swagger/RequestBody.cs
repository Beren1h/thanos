namespace Thanos.Frame.Swagger;

public record RequestBody (
    IEnumerable<Example> Examples
);
