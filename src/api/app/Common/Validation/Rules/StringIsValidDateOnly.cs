using FluentValidation;
using FluentValidation.Results;

namespace Thanos.Common.Validation.Rules;

public static class StampIsValid
{
    public static IRuleBuilder<T, string> IsValidStamp<T> (
        this IRuleBuilder<T, string> builder,
        string propertyName
    ){
        return builder
            .Custom((value, context) => {

                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                if (!DateOnly.TryParse(value, out var date))
                {
                    context.AddFailure(new ValidationFailure {
                        ErrorCode = "invalid-stemp",
                        ErrorMessage = "stamp is invalid",
                        CustomState = new Dictionary<string, object>() {
                            { "property", propertyName }
                        }
                    });
                }
            });
    }
}
