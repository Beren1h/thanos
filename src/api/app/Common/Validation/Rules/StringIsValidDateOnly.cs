using FluentValidation;
using FluentValidation.Results;

namespace Thanos.Common.Validation.Rules;

public static class StringIsValidaDateOnly
{
    public static IRuleBuilder<T, string> IsValidDateOnly<T> (
        this IRuleBuilder<T, string> builder,
        string propertyName
    ){
        return builder
            .Custom((value, context) => {

                if (!DateOnly.TryParse(value, out var date))
                {
                    context.AddFailure(new ValidationFailure {
                        ErrorCode = "invalid-date",
                        ErrorMessage = "value cannot be converted to DateOnly type",
                        CustomState = new Dictionary<string, object>() {
                            { "property", propertyName }
                        }
                    });
                }
            });
    }
}
