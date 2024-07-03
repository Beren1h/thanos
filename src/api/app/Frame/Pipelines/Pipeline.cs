namespace Thanos.Frame.Pipelines;

public class Pipeline<T>
{
    private readonly List<Delegate<T>> _steps = [];

    public void Add(Delegate<T> step)
    {
        _steps.Add(step);
    }

    public async Task Run(T context)
    {
        Delegate<T> pipeline = null;

        foreach(var step in _steps)
        {
            pipeline += step;
        }

        foreach(Delegate<T> step in pipeline.GetInvocationList().Cast<Delegate<T>>())
        {
            await step(context);
        }
    }
}
