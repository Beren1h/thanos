namespace Thanos.Frame.Pipelines;

public delegate Task<T> Delegate<T>(T context);
