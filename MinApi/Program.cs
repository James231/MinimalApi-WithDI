using MinApi.Services;
using MinApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Builds ServiceProvider for DI. Includes all controllers classes found with reflection.
IEnumerable<Type> controllers = GetControllers();
IServiceCollection serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);
foreach (Type t in controllers)
{
    serviceCollection.AddTransient(t);
}
var serviceProvider = serviceCollection.BuildServiceProvider();

foreach (Type t in controllers)
{
    if (t == null) { return; }

    IController instance = (IController)serviceProvider.GetService(t);
    if (instance == null)
    {
        continue;
    }

    var attr = GetAttribute(t);
    // Create routes to controllers 
    app.MapMethods(attr.endpoint, new[]{ attr.method }, instance.Invoked);
}

app.Run();

ApiControllerAttribute GetAttribute(Type t)
{
    ApiControllerAttribute contAttri = (ApiControllerAttribute)Attribute.GetCustomAttribute(t, typeof(ApiControllerAttribute));
    if (contAttri == null) { return null; }
    return contAttri;
}

IEnumerable<Type> GetControllers()
{
    var type = typeof(IController);
    return AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => type.IsAssignableFrom(p) && !p.IsInterface && GetAttribute(p) != null);
}

void ConfigureServices(IServiceCollection services)
{
    // Inject your own services here
    services.AddSingleton<MyService>();
}