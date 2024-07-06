using FluentValidation;
using Thanos.Common.Validation;
using Thanos.Common.Validation.Rules;

namespace Thanos.Domains.Accounts.Create;

public class Validator : AbstractValidator<Validator.Model>
{
    public Validator()
    {
        var valueName = nameof(Model.Value);

        RuleFor(m => m.Value)
            .HasValue(valueName)
            .MustNotBeInList(ContextKeys.ACCOUNTS, valueName);
    }

    public record Model (
        Request Request
    ){
        public string Value => Request?.Value;
    };
}
