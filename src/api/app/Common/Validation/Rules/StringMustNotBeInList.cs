using FluentValidation;
using FluentValidation.Results;

namespace Thanos.Common.Validation.Rules;

public static class StringMustNotBeInList
{
    public static IRuleBuilder<T, string> MustNotBeInList<T> (
        this IRuleBuilder<T, string> builder,
        string key,
        string propertyName
    ){
        return builder
            .Custom((value, context) => {
                
                if (!context.RootContextData.TryGetValue(key, out object raw))
                {
                    throw new Exception($"validation context undefined");
                }

                var currentValues = raw as IEnumerable<string>;

                if (!currentValues.Any())
                {
                    return;
                }

                if (currentValues.Contains(value))
                {
                    context.AddFailure(new ValidationFailure {
                        ErrorCode = "value-in-list",
                        ErrorMessage = "value is alerady in list",
                        CustomState = new Dictionary<string, object>() {
                            { "property", propertyName },
                            { "value", value },
                            { "current", currentValues }
                        }
                    });
                }
            });
    }
}
