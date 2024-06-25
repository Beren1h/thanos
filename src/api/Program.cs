
using Thanos.Frame.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.AddToBuilder();

var app = builder.Build();

app.UseWithApp();

app.MapGet("/", () => "works");

app.Run();
