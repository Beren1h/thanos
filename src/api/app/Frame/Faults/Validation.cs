using FluentValidation;

namespace Thanos.Frame.Faults;

public class Validation(IEnumerable<FluentValidation.Results.ValidationFailure> errors) : ValidationException(errors)
{}
