using FluentValidation.Results;

namespace Thanos.Frame.Validation;

public class Failure : ValidationFailure
{
    public Failure()
    {
        base.CustomState = new Dictionary<string, object>();
    }

    public new IDictionary<string, object> CustomState
    {
        get { return base.CustomState as Dictionary<string, object>; }
        set { base.CustomState = value; }
    }
}
