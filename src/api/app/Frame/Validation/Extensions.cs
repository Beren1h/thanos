using FluentValidation;
using FluentValidation.Results;
using Thanos.Common.Validation;

namespace Thanos.Frame.Validation.Extensions;

public static class Extensions
{
    public static ValidationContext<T> Build<T> (
        this T model
    ){
        return new ValidationContext<T>(model);
    }

    public static ValidationContext<T> Add<T> (
        this ValidationContext<T> context,
        IEnumerable<Datastore.Account> accounts
    ){
        context.RootContextData.Add (
            ContextKeys.ACCOUNTS,
            accounts.Select(t => t.Value)
        );

        return context;
    }

    public static ValidationContext<T> Add<T> (
        this ValidationContext<T> context,
        IEnumerable<Datastore.Tag> tags
    ){
        context.RootContextData.Add (
            ContextKeys.TAGS,
            tags.Select(t => t.Value)
        );

        return context;
    }

    public static ValidationContext<T> Add<T> (
        this ValidationContext<T> context
    ){
        context.RootContextData.Add (
            "",
            new object()
        );

        return context;
    }

    public static Response AsCustomResponse (
        this IEnumerable<ValidationFailure> failures
    ){
        return new Response (
            failures.Select(f => new Error (
                Code: f.ErrorCode,
                Message: f.ErrorMessage,
                Metadata: f.CustomState as IDictionary<string, object>
            ))
        );
    }
}
