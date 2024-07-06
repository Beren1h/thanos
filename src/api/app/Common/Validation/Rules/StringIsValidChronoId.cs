using FluentValidation;
using FluentValidation.Results;

namespace Thanos.Common.Validation.Rules;

public static class StringIsValidChronoId
{
    public static IRuleBuilder<T, string> IsValidChronoId<T> (
        this IRuleBuilder<T, string> builder
    ){
        return builder
            .Custom((value, context) => {

                var chronoParts = value.Split("-").ToList();
                var date = string.Empty;

                switch (chronoParts.Count)
                {
                    case 1:
                        date = $"{chronoParts[0]}-01-01";
                    break;
                    case 2:
                        date = $"{chronoParts[0]}-{chronoParts[1]}-01";
                    break;
                    case 3:
                        date = value;
                    break;
                    default:
                        context.AddFailure(new ValidationFailure {
                            ErrorCode = "chrono-invalid-segment-count",
                            ErrorMessage = "chronoId must have 1 to 3 segments",
                            CustomState = new Dictionary<string, object>() {
                                { "value", value }
                            }
                        });                    
                    break;
                }

                if (!DateOnly.TryParse(date, out var dateParse))
                {
                    context.AddFailure(new ValidationFailure {
                        ErrorCode = "chrono-non-date",
                        ErrorMessage = "chronoId cannot be parse to date",
                        CustomState = new Dictionary<string, object>() {
                            { "value", value }
                        }
                    });
                }
            });
    }
}
