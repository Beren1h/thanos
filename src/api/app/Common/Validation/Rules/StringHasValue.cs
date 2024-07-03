using FluentValidation;
using FluentValidation.Results;

namespace Thanos.Common.Validation.Rules;

public static class StringHasValue
{
    public static IRuleBuilder<T, string> HasValue<T> (
        this IRuleBuilder<T, string> builder,
        string propertyName
    ){
        return builder
            .Custom((value, context) => {

                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    context.AddFailure(new ValidationFailure {
                        ErrorCode = "no-value",
                        ErrorMessage = "value cannot be null, empty, or whitespace",
                        CustomState = new Dictionary<string, object>() {
                            { "property", propertyName }
                        }
                    });
                }
            });
    }
}
