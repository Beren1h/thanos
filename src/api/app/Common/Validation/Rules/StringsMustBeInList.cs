using FluentValidation;
using FluentValidation.Results;

namespace Thanos.Common.Validation.Rules;

public static class StringMustBeInList
{
    public static IRuleBuilder<T, IEnumerable<string>> MustBeInList<T> (
        this IRuleBuilder<T, IEnumerable<string>> builder,
        string key,
        string propertyName
    ){
        return builder
            .Custom((values, context) => {
                
                if (values == null)
                {
                    return;   
                }

                if (!context.RootContextData.TryGetValue(key, out object raw))
                {
                    throw new Exception($"validation context undefined");
                }

                var currentValues = raw as IEnumerable<string>;

                if (!currentValues.Any())
                {
                    return;
                }

                var existingValues = values.Where(v => currentValues.Contains(v));

                var unmatchedValues = values.Except(existingValues);

                if (unmatchedValues.Any())
                {
                    string unmatched;

                    if (unmatchedValues.Count() == 1)
                    {
                        unmatched = unmatchedValues.First();
                    }
                    else
                    {
                        unmatched = string.Join(", ", unmatchedValues);
                    }

                    context.AddFailure(new ValidationFailure {
                        ErrorCode = "value-not-in-list",
                        ErrorMessage = "value(s) not in the list",
                        CustomState = new Dictionary<string, object>() {
                            { "property", propertyName },
                            { "value(s)", unmatched },
                            { "current", string.Join(", ", existingValues) }
                        }
                    });
                }
            });
    }
}
