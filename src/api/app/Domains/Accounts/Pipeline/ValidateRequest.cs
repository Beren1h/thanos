using FluentValidation;
using Thanos.Frame.Results.Extensions;
using Thanos.Frame.Validation.Extensions;

namespace Thanos.Domains.Accounts.Create;

public class ValidateRequest (
    Datastore.Gateway _datastore,
    IValidator<Validator.Model> _validator,
    FrameResults.Builder _resultBuilder
){
    public async Task<Context> Invoke(Context context)
    {
        var result = _resultBuilder.Build(() => {

            var accounts = _datastore.Get<Datastore.Account>();

            var validationContext = new Validator.Model(context.Request)
                .Build()
                .Add(accounts)
                ;

            var validationResult = _validator.Validate(validationContext);

            if (!validationResult.IsValid)
            {
                context.HandlingResult = new Faults.Validation(validationResult.Errors);
            }

            return context;
        });

        if (result.IsFaulted())
        {
            context.HandlingResult = result.Fault;
        }

        return await Task.FromResult(context);
    }
}
