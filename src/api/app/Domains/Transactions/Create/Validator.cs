using FluentValidation;
using Thanos.Common.Validation;
using Thanos.Common.Validation.Rules;

namespace Thanos.Domains.Transactions.Create;

public class Validator : AbstractValidator<Validator.Model>
{
    public Validator()
    {
        // RuleFor(m => m.Date)
        //     .IsValidDateOnly(nameof(Model.Date));

        RuleFor(m => m.Request.Tags)
            .MustBeInList(ContextKeys.TAGS, nameof(Model.Request.Tags));
        // var valueName = nameof(Model.Value);

        // RuleFor(m => m.Value)
        //     .HasValue(valueName)
        //     .IsNotInList(ContextKeys.TAGS, valueName);
    }

    public record Model (
        Request Request
    ){
        //public string Date => Request?.Date;
        //public IEnumerable<string> Tags => Request?.Tags;
    };
}
