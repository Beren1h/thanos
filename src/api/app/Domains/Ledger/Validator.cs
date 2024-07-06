using FluentValidation;
using Thanos.Common.Validation;
using Thanos.Common.Validation.Rules;

namespace Thanos.Domains.Ledger;

public class Validator : AbstractValidator<Validator.Model>
{
    public Validator()
    {
        RuleFor(m => m.Request.ChronoId).IsValidChronoId();
        RuleFor(m => m.Request.Tags).MustBeInList(ContextKeys.TAGS, nameof(Model.Request.Tags));
    }

    public record Model (
        Request Request
    );
}
