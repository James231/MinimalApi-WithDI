using MinApi.Services;
namespace MinApi.Controllers;

// Creates endpoint at https://localhost:5001/example
[ApiController("GET", "example")]
public class ExampleController : IController
{
    public MyService MyService { get; set; }

    // Custom service injected here.
    public ExampleController(MyService _myService)
    {
        MyService = _myService;
    }

    public string Invoked(HttpContext context)
    {
        return MyService.Echo("example");
    }
}
