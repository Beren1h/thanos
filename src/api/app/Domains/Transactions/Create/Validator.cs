using FluentValidation;
using Thanos.Common.Validation;
using Thanos.Common.Validation.Rules;

namespace Thanos.Domains.Transactions.Create;

public class Validator : AbstractValidator<Validator.Model>
{
    public Validator()
    {
        RuleFor(m => m.Request.Stamp)
            .IsValidStamp(nameof(Model.Request.Stamp));

        RuleFor(m => m.Request.Tags)
            .MustBeInList(ContextKeys.TAGS, nameof(Model.Request.Tags));

        RuleFor(m => new List<string>{m.Request.Account})
            .MustBeInList(ContextKeys.ACCOUNTS, nameof(Model.Request.Account));
    }

    public record Model (
        Request Request
    );
}
