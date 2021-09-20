namespace MinApi;

[ApiController("example")]
public class ExampleController : IController
{
    public MyService MyService { get; set; }

    public ExampleController(MyService _myService)
    {
        MyService = _myService;
    }

    public string Invoked(HttpContext context)
    {
        return MyService.Echo("example");
    }
}
