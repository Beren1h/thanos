using FluentValidation;
using Thanos.Common.Validation.Rules;

namespace Thanos.Domains.Helpers.Chrono;

public class Validator : AbstractValidator<Validator.Model>
{
    public Validator()
    {
        RuleFor(m => m.ChronoId)
            .IsValidChronoId();
    }

    public record Model (
        Request Request
    ){
        public string ChronoId = $"{Request.Year}-{Request.Month}";
    };
}
