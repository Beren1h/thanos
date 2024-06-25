namespace Thanos.Frame.Startup;

public static class Extensions
{
    public static void AddToBuilder(this WebApplicationBuilder builder)
    {
        var startups = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(s => typeof(IAddToBuilder).IsAssignableFrom(s) && s.IsClass);

        foreach(var startup in startups)
        {
            var instance = (IAddToBuilder)Activator.CreateInstance(startup);
            instance.Add(builder);
        }
    }

    public static void UseWithApp(this WebApplication app)
    {
        var startups = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(s => typeof(IUseWithApp).IsAssignableFrom(s) && s.IsClass);

        foreach(var startup in startups)
        {
            var instance = (IUseWithApp)Activator.CreateInstance(startup);
            instance.Use(app);
        }
    }
}
