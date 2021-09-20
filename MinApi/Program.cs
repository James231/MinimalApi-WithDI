using MinApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

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

    string endpointPath = GetEndpointPath(t);
    app.MapGet(endpointPath, instance.Invoked);
}

app.Run();

string GetEndpointPath(Type t)
{
    ApiControllerAttribute contAttri =
        (ApiControllerAttribute)Attribute.GetCustomAttribute(t, typeof(ApiControllerAttribute));
    if (contAttri == null) { return null; }
    return contAttri.endpoint;
}

void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<MyService>();
}

IEnumerable<Type> GetControllers()
{
    var type = typeof(IController);
    return AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => type.IsAssignableFrom(p) && !p.IsInterface && GetEndpointPath(p) != null);
}